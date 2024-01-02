using UnityEngine;
using Cinemachine;

public class LookAtCameraCheck : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private SwitchingCameraController _switchingCameraController;
    
    [Space(10)]
    
    [Header("Cameras")]
    [SerializeField] public Camera _mainCamera; 
    
    private CinemachineVirtualCamera _selectedCamera;
    private void FixedUpdate()
    {
        var camForward = _mainCamera.transform.forward;
        RaycastHit hit;
        
        if (Physics.Raycast(_mainCamera.transform.position, camForward, out hit) && hit.collider.CompareTag("Camera"))
        {
            if (!_selectedCamera)
            {
                _selectedCamera = hit.transform.GetComponent<CinemachineVirtualCamera>();
            }
        }
        else
        {
            if (_selectedCamera)
                _selectedCamera = null;
        }

        _switchingCameraController.SelectedCamera = _selectedCamera;
    }
}
