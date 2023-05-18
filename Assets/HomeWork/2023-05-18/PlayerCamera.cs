using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private GameObject zoomcamera;

    private void Start()
    {
        virtualCamera = zoomcamera.GetComponent<CinemachineVirtualCamera>();
    }
    private void OnZoomin(InputValue value)
    {
        if (value.isPressed)
        {
            virtualCamera.Priority = 100;
        }
        else
        {
            virtualCamera.Priority = 10;
        }
    }
}
