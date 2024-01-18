using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleTileColliderTrigger : MonoBehaviour
{
    [SerializeField] public UnityEvent<string, bool> OnConnectionCheck;
    [SerializeField] public UnityEvent<PuzzleTilePower, bool> OnTriggerGetComponent;

    [SerializeField] public PuzzleTilePower _puzzleTilePower;
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEvent(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerEvent(other, false);
    }

    private void OnTriggerEvent(Collider other, bool state)
    {
        if (other.CompareTag("PowerSourceTile"))
        {
            _puzzleTilePower.IsPowered = state;
        }
        else if (!other.CompareTag("Tile"))
            return;
        
        if (other.TryGetComponent<PuzzleTileColliderTrigger>(out var puzzleTileColliderTrigger))
        {
            OnTriggerGetComponent.Invoke(puzzleTileColliderTrigger._puzzleTilePower,state);
        }
        OnConnectionCheck.Invoke(name, state);
        
    }
}