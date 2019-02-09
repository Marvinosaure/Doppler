using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureTarget : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    private Transform _positionRay;
    private GameObject _currentTarget;
    private GameObject _character;

    private void Start()
    {
        _character = GameObject.FindWithTag("Player");
        _positionRay = _character.transform.Find("PositionCameraFP");
    }

    private void Update()
    {
        if(_character != null)
        {
            _ray = new Ray(_positionRay.position, _character.transform.TransformDirection(Vector3.forward));

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                _currentTarget = GameObject.Find(_hit.collider.name);
            }

            Debug.DrawRay(_positionRay.position, _character.transform.TransformDirection(Vector3.forward) * 10f, Color.yellow);
        }
    }

    public void CreateCharacter()
    {
        if (_character == null) return;

        if (_currentTarget)
        {
            _currentTarget = Instantiate
            (
                _currentTarget, 
                new Vector3(_character.transform.position.x, _currentTarget.transform.position.y, _character.transform.position.z), 
                _character.transform.rotation                
            );

            _currentTarget.tag = "Player";

            _currentTarget.AddComponent<AnimatorController>();
            _currentTarget.AddComponent<CharacterController>();
            _currentTarget.AddComponent<CharacterEventsController>();

            

            Destroy(_character);
            _character = _currentTarget;
        }
    }
}
