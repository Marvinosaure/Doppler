using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraComponent : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private int _rotationSpeed = 3;

    private Vector3 _offset;

    private void Start()
    {
        InitCamera();        
    }

    private void LateUpdate()
    {        
        transform.position = _character.transform.position + _offset;

        Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _rotationSpeed, Vector3.up);
        _offset = turnAngle * _offset;

        transform.LookAt(new Vector3(_character.transform.position.x, transform.position.y, _character.transform.position.z));        
    }

    private void InitCamera()
    {
        _offset = transform.position - _character.transform.position;
    }
}
