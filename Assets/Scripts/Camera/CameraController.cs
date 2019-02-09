using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CaptureTarget _captureTarget;

    private void Start()
    {
        _captureTarget = GetComponent<CaptureTarget>();
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            _captureTarget.CreateCharacter();
        } 
    }
}
