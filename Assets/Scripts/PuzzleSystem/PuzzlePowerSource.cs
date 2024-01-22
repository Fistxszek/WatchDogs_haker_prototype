using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
public class PuzzlePowerSource : MonoBehaviour
{
    public bool IsSourceConnected;
    [SerializeField] public List<PuzzleTilePower> TilesConnected;
    [SerializeField] private List<PuzzleTilePower> _tiles = new List<PuzzleTilePower>();

    private void AddToList(PuzzleTilePower tile, PuzzleTilePower adder)
    {
        if (!TilesConnected.Contains(tile))
        {
            TilesConnected.Add(tile);
            tile.whoAddedYou = adder;
        }
    }
    private void RemoveFromList(PuzzleTilePower tile, PuzzleTilePower adder)
    {
        if (TilesConnected.Contains(tile) && (tile.whoAddedYou == adder || !adder))
        {
            tile.ResetPower();
            tile.whoAddedYou = null;
            if (!adder)
                TilesConnected.Remove(tile);
        }
    }

    public void ChangeTheList(PuzzleTilePower tile, bool status, PuzzleTilePower adder)
    {
        if (status)
            AddToList(tile, adder);
        else
            RemoveFromList(tile, adder);
    }
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEvent(other, true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Tile"))
            return;
       // AddConnectedListToMainList();
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerEvent(other, false);
    }

    private void OnTriggerEvent(Collider other, bool state)
    {
        if (!other.CompareTag("Tile"))
            return;
        
        var tilePuzzleTile = other.GetComponentInParent<PuzzleTilePower>();
        if (state)
        {
            AddToList(tilePuzzleTile, null);
            AddToTilesList(tilePuzzleTile);
            CheckIsSourceConnected();
        }
        else
        {
           RemoveFromList(tilePuzzleTile, null);
           RemoveFromTilesList(tilePuzzleTile);
           CheckIsSourceConnected();
        }
    }

    private void AddToTilesList(PuzzleTilePower tile)
    {
        if (!_tiles.Contains(tile))
            _tiles.Add(tile);
    }
    private void RemoveFromTilesList(PuzzleTilePower tile)
    {
        if (_tiles.Contains(tile))
            _tiles.Remove(tile);
    }
    private void AddConnectedListToMainList()
    {
        foreach (var item in _tiles)
        {
            AddToList(item, null);
        }
    }

    private void CheckIsSourceConnected()
    {
        IsSourceConnected = _tiles.Count > 0;
    }
}
