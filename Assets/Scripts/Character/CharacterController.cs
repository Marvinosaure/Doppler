using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private int _speed = 3;
    [SerializeField] private int _jumpForce = 350;
    [SerializeField] private int _rotationSpeed = 7;

    private float _deltaV = 0;
    private float _deltaH = 0;    

    private bool _mooving = false;
    public bool Mooving
    {
        get { return _mooving; }
        set { _mooving = value; }
    }

    private bool _isRunning = true;
    public bool IsRunnig
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public void MoveForward()
    {        
        _deltaV = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * _speed * _deltaV * Time.fixedDeltaTime);
    }

    public void RotationLerp(Transform b)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, b.rotation, _rotationSpeed * Time.fixedDeltaTime);
    }

    public void RotationCharacter()
    {
        transform.Rotate(Vector3.up * 150 * Input.GetAxis("Mouse X") * Time.fixedDeltaTime);
    }

    public void Jump()
    {        
         GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce);        
    }
}