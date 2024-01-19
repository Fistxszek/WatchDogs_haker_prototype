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
    [SerializeField] private PuzzleTilePower _tile;

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
        if (TilesConnected.Contains(tile) && tile.whoAddedYou == adder)
        {
            tile.ResetPower();
            tile.whoAddedYou = null;
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
        AddToList(_tile, null);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerEvent(other, false);
    }

    private void OnTriggerEvent(Collider other, bool state)
    {
        if (!other.CompareTag("Tile"))
            return;
        IsSourceConnected = state;
        _tile = other.GetComponentInParent<PuzzleTilePower>();
        if (state)
            AddToList(_tile, null);
        else
        {
            RemoveFromList(_tile, null);
            ClearList();
        }
    }

    private void ClearList()
    {
        TilesConnected.Clear();
    }
}
