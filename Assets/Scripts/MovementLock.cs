using System;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class MovementLock : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _playerCamera; 
        [SerializeField] private FirstPersonController _firstPersonController;
        [SerializeField] private StarterAssetsInputs _starterAssetsInputs;
        [SerializeField] private ConsoleVisibility _consoleVisibility;

        private void Update()
        {
            if (_playerCamera.Priority == 0 || _consoleVisibility.isActive)
            {
                _firstPersonController.isLocked = true;
                _firstPersonController.isLookLocked = true;
            }            
            else
            {
                _firstPersonController.isLocked = false;
                _firstPersonController.isLookLocked = false;
            }        
        }
    }
}