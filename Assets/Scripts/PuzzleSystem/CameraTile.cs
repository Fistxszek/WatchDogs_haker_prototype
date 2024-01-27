using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraTile : MonoBehaviour
{
    [SerializeField] private GameObject _cameraReference;
    [SerializeField] private bool _isCameraActive;
    [SerializeField] private PuzzlePowerSource _puzzlePowerSource;
    [SerializeField] private PuzzleController _puzzleController;
    private float _waitTime;
    [SerializeField]private PuzzleTilePower _neighbourTile;
    private CameraActive _cameraActive;
    private void Awake()
    {
        _waitTime = _puzzleController.PuzzleTileRefreshTime;
        _cameraActive = _cameraReference.GetComponent<CameraActive>();
        StartCoroutine(Wait());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Tile")) 
            return;
        Debug.Log(other.name);
        _neighbourTile = other.GetComponentInParent<PuzzleTilePower>();

    }

    private void OnTriggerExit(Collider other)
    {
        _neighbourTile = null;
    }

    IEnumerator Wait()
    {
        while (true)
        {
            if (_neighbourTile)
                _isCameraActive = _puzzlePowerSource.TilesConnected.Contains(_neighbourTile);
            else
                _isCameraActive = false;
            _cameraActive.IsCameraActive = _isCameraActive;
            yield return new WaitForSeconds(_waitTime);
        }
    }
}
