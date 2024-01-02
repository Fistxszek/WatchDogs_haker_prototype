using System.ComponentModel;
using UnityEngine;
using Cinemachine;

public class SwitchingCameraController : MonoBehaviour
{
    [Header("Virtual Cameras")]
    public CinemachineVirtualCamera PlayerCamera; 
    public CinemachineVirtualCamera SelectedCamera;
    public CinemachineVirtualCamera CurrentCamera;
    private void Awake()
    {
        
    }
    
}
