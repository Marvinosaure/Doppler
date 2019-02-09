using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraComponent : MonoBehaviour
{    
    [SerializeField] private int _rotationSpeed = 3;

    private GameObject _character;
    private Transform _positionCameraTP;
    private Transform _positionCameraFP;
    private Vector3 _offset;

    private bool _FPViewMode;
    public bool FPViewMode
    {
        get { return _FPViewMode; }
    }

    private void Start()
    {
        InitPlayer();
        InitCamera();        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
            SwitchViewMode();
    }

    private void LateUpdate()
    {
        if(_character != null)
        {        
            if (!_FPViewMode)
            {
                transform.position = _character.transform.position + _offset;

                Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _rotationSpeed, Vector3.up);
                _offset = turnAngle * _offset;

                transform.LookAt(new Vector3(_character.transform.position.x, transform.position.y, _character.transform.position.z));
            }
            else
            {
                transform.position = _positionCameraFP.position;
                transform.rotation = _positionCameraFP.rotation;
            }
        }
    }

    private void InitCamera()
    {
        if (_character == null) return;

        _positionCameraTP = _character.transform.Find("PositionCameraTP").transform;
        _positionCameraFP = _character.transform.Find("PositionCameraFP").transform;
        transform.position = _positionCameraTP.position;
        _offset = transform.position - _character.transform.position;
        _FPViewMode = false;
    }

    public void SwitchViewMode()
    {
        if (_character == null) return;

        if(!_FPViewMode)
        {
            transform.position = _positionCameraFP.position;
            _FPViewMode = true;
        }
        else
        {
            transform.position = _positionCameraTP.position;
            _FPViewMode = false;
        }
    }

    public void InitPlayer()
    {
        _character = GameObject.FindWithTag("Player");
    }
}
