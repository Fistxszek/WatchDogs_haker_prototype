using System;
using UnityEngine;
using Cinemachine;

public class ChangeCameraPriority : MonoBehaviour
{
    [SerializeField] private SwitchingCameraController _switchingCameraController;
    [SerializeField] private CinemachineVirtualCamera _currentCamera;
    [SerializeField] private CinemachineVirtualCamera _selectedCamera;
    [SerializeField] private CinemachineVirtualCamera _playerCamera;

    private void Awake()
    {
        _playerCamera = _switchingCameraController.PlayerCamera;
    }

    public void ChangePriority()
    {
        _selectedCamera = _switchingCameraController.SelectedCamera;
        
        if (_selectedCamera != null)
        {
            _currentCamera = _switchingCameraController.CurrentCamera;
            
            _selectedCamera.Priority = 1;
            _currentCamera.Priority = 0;

            _currentCamera = _selectedCamera;
            _selectedCamera = null;
        }
        else if (_currentCamera != _playerCamera && _currentCamera != null)
        {
            _playerCamera.Priority = 1;
            _currentCamera.Priority = 0;
        }
    }
}
