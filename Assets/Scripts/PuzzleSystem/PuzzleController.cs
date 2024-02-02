using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PuzzleController : MonoBehaviour
{
    [SerializeField]private LookAtCameraCheck _lookAtCameraCheck;
    private GameObject _selectedPuzzleTile;
    [SerializeField] public float PuzzleTileRefreshTime;
    [SerializeField] public float RotationObjectTime;
    [SerializeField] public bool IsPuzzle3D;

    [SerializeField] private UnityEvent<int> OnSelectedRemove; 
    [SerializeField] private UnityEvent<string, Sprite> OnSelectedAdd; 

    [SerializeField] public List<GameObject> SelectedList = new List<GameObject>();

    private void Awake()
    {
        _lookAtCameraCheck = (LookAtCameraCheck)FindObjectOfType(typeof(LookAtCameraCheck));
    }

    public void OnInputRotateSelectedPuzzleTile()
    {
       _selectedPuzzleTile = _lookAtCameraCheck.SelectedPuzzleTile;
       if (_selectedPuzzleTile == null)
           return;
       var selectedRotateObject = _selectedPuzzleTile.GetComponent<RotateObject>();
       selectedRotateObject.RotateOnInput();
    }

    public void OnInputSelectPuzzleToFix()
    {
        _selectedPuzzleTile = _lookAtCameraCheck.SelectedPuzzleTile;
        if (_selectedPuzzleTile == null)
            return;
        var selectedTileObject = _selectedPuzzleTile.GetComponent<PuzzleTileFace>().selectedGameObject;
           
        if (!selectedTileObject.activeSelf)
        {
            var selectedTileFaceScript = selectedTileObject.GetComponentInParent<PuzzleTileFace>();
            
            selectedTileObject.name = selectedTileFaceScript.name.ToLower();
            selectedTileObject.SetActive(true);
            if (SelectedList.Count >= 3)
            {
                SelectedList[0].SetActive(false);
                SelectedList.Remove(SelectedList[0]);
                
                OnSelectedRemove.Invoke(0);
            }
            SelectedList.Add(selectedTileObject);
            OnSelectedAdd.Invoke(selectedTileObject.name, selectedTileFaceScript.UIFaceImage);
        }
        else
        {
            selectedTileObject.SetActive(false);
            var index = SelectedList.IndexOf(selectedTileObject);
            
            OnSelectedRemove.Invoke(index);
            SelectedList.Remove(selectedTileObject);
        }
    }
}
