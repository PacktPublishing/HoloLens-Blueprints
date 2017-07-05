using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotate Voice Command
/// </summary>
public class RotateVoiceCommandHandler : MonoBehaviour
{
    private bool isRotating = false;

    // Method for Start Rotate Voice Command 
    public void StartRotate()
    {
        isRotating = true;
    }

    // Method for Stop Rotate Voice Command 
    public void StopRoate()
    {
        isRotating = false;
    }

    // This method gets call for each frame.
    // Depends on Rotation Status (isRotating) it object will be transformed

    void Update()
    {
        if (isRotating)


        {
            transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
        }
    }
}

