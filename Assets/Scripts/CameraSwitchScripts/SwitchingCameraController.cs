using System;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class SwitchingCameraController : MonoBehaviour
{
    [Header("Virtual Cameras")]
    public CinemachineVirtualCamera PlayerCamera; 
    public CinemachineVirtualCamera SelectedCamera;
    public CinemachineVirtualCamera CurrentCamera;
    public FirstPersonController FirstPersonController;

    //private void Update()
    //{
    //    if (PlayerCamera.Priority == 0)
    //        FirstPersonController.isLocked = true;
    //    else
    //        FirstPersonController.isLocked = false;
    //}
}
