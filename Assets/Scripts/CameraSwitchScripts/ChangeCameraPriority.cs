using System;
using UnityEngine;
using Cinemachine;

public class ChangeCameraPriority : MonoBehaviour
{
    [SerializeField] private SwitchingCameraController _switchingCameraController;
    private CinemachineVirtualCamera _currentCamera;
    private CinemachineVirtualCamera _selectedCamera;
    private CinemachineVirtualCamera _playerCamera;

    private void Awake()
    {
        _switchingCameraController = gameObject.GetComponent<SwitchingCameraController>();
        _playerCamera = _switchingCameraController.PlayerCamera;
        _currentCamera = _switchingCameraController.CurrentCamera;
    }

    public void ChangePriority()
    {
        _selectedCamera = _switchingCameraController.SelectedCamera;
        if (_selectedCamera != null)
        {
            var camActive = _selectedCamera.GetComponent<CameraActive>().IsCameraActive;
            if (!camActive)
                return;
            
            PrioritySwitch(_selectedCamera, _currentCamera);
            _currentCamera = _selectedCamera;
            _selectedCamera = null;
        }
        else if (_currentCamera != _playerCamera)
        {
            PrioritySwitch(_playerCamera, _currentCamera);
            _currentCamera = _playerCamera;
        }

        _switchingCameraController.SelectedCamera = _selectedCamera;
        _switchingCameraController.CurrentCamera = _currentCamera;
    }

    private static void PrioritySwitch(CinemachineVirtualCamera camA, CinemachineVirtualCamera camB)
    {
        camA.Priority = 1;
        camB.Priority = 0;
    }
}
