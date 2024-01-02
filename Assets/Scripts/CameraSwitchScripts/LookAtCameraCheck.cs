using System;
using UnityEngine;
using Cinemachine;

public class LookAtCameraCheck : MonoBehaviour
{
    [SerializeField] public Camera _mainCamera; 
    [SerializeField] private CinemachineVirtualCamera _currentCamera;

    private void FixedUpdate()
    {
        
        Vector3 camForward = _mainCamera.transform.forward;
        RaycastHit hit;
        
        
        if (Physics.Raycast(_mainCamera.transform.position, camForward, out hit) && hit.collider.CompareTag("Camera"))
        {
            if (_currentCamera == null)
            {
                _currentCamera = hit.transform.GetComponent<CinemachineVirtualCamera>();
            }
        }
        else
        {
            if (_currentCamera != null)
            {
                _currentCamera = null;
            }
        }
    }
}
