using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTileConnectionChecker : MonoBehaviour
{
    [Header("Scripts"), SerializeField]
    private PuzzleTileFace _puzzleTileFace;
    
    [Space(10), Header("Shape")]
    [SerializeField] public bool _isTopConnected;
    [SerializeField] public bool _isBottomConnected;
    [SerializeField] public bool _isLeftConnected;
    [SerializeField] public bool _isRightConnected;

    public void CheckConnection(string objectName, bool state)
    {
        switch (objectName)
        {
            case "top":
                _isTopConnected = state;
               // _activePipes[0].SetActive(state);
                break;
            case "bottom":
                _isBottomConnected = state;
                //_activePipes[1].SetActive(state);
                break;
            case "left":
                _isLeftConnected = state;
               // _activePipes[2].SetActive(state);
                break;
            case "right":
                _isRightConnected = state;
                //_activePipes[3].SetActive(state);
                break;
        }
    }

    public void ResetConnections()
    {
        _isBottomConnected = false;
        _isLeftConnected = false;
        _isRightConnected = false;
        _isTopConnected = false;
    }
}
