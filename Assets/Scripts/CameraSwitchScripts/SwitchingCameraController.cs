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
    
    public void ToggleMovementLock()
    {
        //temporary solution until new movement
        if (SelectedCamera != null || FirstPersonController.isMovementLocked)
            FirstPersonController.isMovementLocked = !FirstPersonController.isMovementLocked;
    }
}
