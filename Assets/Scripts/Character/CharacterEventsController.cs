using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEventsController : MonoBehaviour
{
    private AnimatorController _animatorController;
    private CharacterController _characterController;

    private void Awake()
    {
        _animatorController = GetComponent<AnimatorController>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _characterController.MoveForward();
        
        AxisEvents();
        KeyboardEvents();
    }

    private void AxisEvents()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            if (_characterController.IsRunnig)
            {
                _animatorController.RunAnimation();
            }
            else
            {
                _animatorController.WalkAnimation();
            }

            _characterController.Rotation();
        }
        else
        {
            _animatorController.IdleAnimation();
            _characterController.Mooving = false;
        }            
    }

    private void KeyboardEvents()
    {
        if (Input.GetKeyUp(KeyCode.CapsLock))        
            SwitchStateRun();

        if (Input.GetKeyUp(KeyCode.Space))
            Jump();
    }

    private void SwitchStateRun()
    {
        _characterController.IsRunnig = !_characterController.IsRunnig;
    }

    private void Jump()
    {
        _characterController.Jump();
        _animatorController.JumpAnimation();
    }
}