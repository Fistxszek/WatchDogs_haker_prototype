using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class LookAtCameraCheck : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private SwitchingCameraController _switchingCameraController;
    
    [Space(10)]
    
    [Header("Cameras")]
    [SerializeField] public Camera _mainCamera; 
    
    private CinemachineVirtualCamera _selectedCamera;
    public GameObject SelectedPuzzleTile;

    private ShowInWorldCanvas _selectedShowObject;
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
        else
        {
            SelectedPuzzleTile = null;
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
            else
            {
                if (!_selectedShowObject)
                    _selectedShowObject = _selectedCamera.GetComponentInChildren<ShowInWorldCanvas>();
                
                _selectedShowObject.ShowObject();
            }
        }
        else
        {
            if (_selectedCamera)
            {
                _selectedCamera.GetComponentInChildren<ShowInWorldCanvas>().HideObject();
                _selectedCamera = null;
                _selectedShowObject = null;
            }
        }
    }
}
