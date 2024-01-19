using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField]private LookAtCameraCheck _lookAtCameraCheck;
    private GameObject _selectedPuzzleTile;
    [SerializeField] public float PuzzleTileRefreshTime;
    [SerializeField] public float RotationObjectTime;
    [SerializeField] public bool IsPuzzle3D;

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
}
