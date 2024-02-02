using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPuzzle : MonoBehaviour
{
    [SerializeField] private PuzzleTileFace _puzzleTileFace;
    [SerializeField] private RotateObject _rotateObject;

    private PuzzlePowerSource _puzzlePowerSource;
    private PuzzleTilePower _puzzleTilePower;
    private PipeType _pipeType;
    private void OnEnable()
    {
        _puzzleTileFace = GetComponent<PuzzleTileFace>();
        _rotateObject = GetComponent<RotateObject>();
        _puzzleTilePower = GetComponent<PuzzleTilePower>();
        _puzzlePowerSource = _puzzleTilePower.PuzzlePowerSource;

        _pipeType = _puzzleTileFace.PipeTypeEnum;
        CallSetFaceBroken();
    }

    private void CallSetFaceBroken()
    {
        _puzzleTileFace.IsBroken = true;
        
        _puzzleTileFace.PipeTypeEnum = PipeType.Broken;
        _puzzleTileFace.SetTileFace();
        _puzzlePowerSource.ChangeTheList(_puzzleTilePower, false, null);
    }

    private void SetFaceNormal()
    {
        _puzzleTileFace.IsBroken = false;
        
        _puzzleTileFace.PipeTypeEnum = _pipeType;
        _puzzleTileFace.SetTileFace();
    }
    private void Update()
    {
        _rotateObject.IsBroken = true;
        _puzzleTilePower.IsPowered = false;
    }

    private void OnDisable()
    {
        _rotateObject.IsBroken = false;
        SetFaceNormal();
    }
}
