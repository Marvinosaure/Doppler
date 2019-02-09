using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEventsController : MonoBehaviour
{
    private GameObject _cameraComponent;
    private AnimatorController _animatorController;
    private CharacterController _characterController;
    
    private void Awake()
    {
        _cameraComponent = GameObject.Find("Main Camera");
        _animatorController = GetComponent<AnimatorController>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CharacterAnimationMoveForward();
        KeyboardEvents();        
    }

    private void FixedUpdate()
    {
        _characterController.MoveForward();

        if (_cameraComponent.GetComponent<ThirdPersonCameraComponent>().FPViewMode)
        {
            _characterController.RotationCharacter();
        }        
    }

    private void LateUpdate()
    {
        if (!_cameraComponent.GetComponent<ThirdPersonCameraComponent>().FPViewMode)
        {
            CharacterControllerMoveRotation();            
        }
    }

    private void CharacterAnimationMoveForward()
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
        }
        else
        {
            _animatorController.IdleAnimation();
        }
    }

    private void CharacterControllerMoveRotation()
    {
        if (Input.GetAxis("Vertical") > 0)        
            _characterController.RotationLerp(_cameraComponent.transform);        
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