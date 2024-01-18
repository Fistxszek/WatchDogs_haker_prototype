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
    public GameObject SelectedPuzzleTile;
    private void FixedUpdate()
    {
        var camForward = _mainCamera.transform.forward;
        RaycastHit hit;
        
        if (Physics.Raycast(_mainCamera.transform.position, camForward, out hit))
        {
            CameraTagCheck(hit);
            PuzzleTileTagCheck(hit);
        }

        _switchingCameraController.SelectedCamera = _selectedCamera;
    }
    
    private void PuzzleTileTagCheck(RaycastHit hit)
    {
        if (hit.collider.CompareTag("PuzzleObject"))
        {
            SelectedPuzzleTile = hit.collider.gameObject;
        }
    }
    private void CameraTagCheck(RaycastHit hit)
    {
        if (hit.collider.CompareTag("Camera")) 
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
    }
}
