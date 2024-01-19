using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VInspector.Libs;

public class PuzzleTilePower : MonoBehaviour
{
    [Header("Power")] [SerializeField]
    [HideInInspector]public bool IsPowered;
    [Space(10),Header("Power")] [SerializeField]
    public PuzzlePowerSource PuzzlePowerSource;

    [HideInInspector]private List<PuzzleTilePower> _neighborTiles = new List<PuzzleTilePower>();
    private PuzzleTileFace _puzzleTileFace;

    [HideInInspector] public PuzzleTilePower whoAddedYou;
    private float _waitTime;

    //[SerializeField] public UnityEvent<PuzzleTilePower, bool> OnChangeNeighborsToTheList;

    private void Awake()
    {
        var puzzleController = FindObjectOfType<PuzzleController>();

        _waitTime = puzzleController.PuzzleTileRefreshTime;
        _puzzleTileFace = this.GetComponent<PuzzleTileFace>();
        StartCoroutine(Wait());
    }

    private void Update()
    {
        _puzzleTileFace.ActiveMaterial(IsPowered);
    }
    public void ResetPower()
    {
        if (!IsPowered)
            return;
        
        IsPowered = false;
        PuzzlePowerSource.TilesConnected.Remove(this);
        foreach (var item in _neighborTiles)
        {
            if (whoAddedYou != item)
            {
                item.ResetPower();
            }
        }
    }
    public void ActivateTile(PuzzleTilePower other, bool status)
    {
       ChangeNeighbor(other, status);
       PowerUp();
    }

    private void PowerUp()
    {
       IsPowered = IsConnectedToSource();
    }
    private void ChangeNeighbor(PuzzleTilePower changedNeighbor, bool status)
    {
        if(status && !_neighborTiles.Contains(changedNeighbor))
        {
            _neighborTiles.Add(changedNeighbor);
        }
        else if(!status)
        {
            _neighborTiles.Remove(changedNeighbor);
            PuzzlePowerSource.ChangeTheList(changedNeighbor, false, this);
        }
    }
    private bool IsConnectedToSource()
    {
        if (PuzzlePowerSource.TilesConnected.Contains(this))
        {
            ConnectNeighborsToSource();
            return true;
        }
        else
            return false;
    }
    private void ConnectNeighborsToSource()
    {
        foreach (var item in _neighborTiles)
        {
            PuzzlePowerSource.ChangeTheList(item, true, this);
        }
    }

    IEnumerator Wait()
    {
        while(true)
        {
            PowerUp();
            yield return new WaitForSeconds(_waitTime);
        }
    }
}
