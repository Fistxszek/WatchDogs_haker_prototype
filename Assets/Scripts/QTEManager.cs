using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

[System.Serializable]
public class QteKey
{
    public InputAction KeyCode;
    public string ButtonName = "";
}

public enum CombinationType
{
    Single,
    Dual,
    Triple
}
public class QTEManager : MonoBehaviour
{
    [SerializeField] private List<QteKey> _qteKeys;
    private CombinationType _combinationType;

    [SerializeField] private List<QteKey> _keysSelected;
    private bool isChecking;
    private int _multiplier;
    [SerializeField] private UnityEvent<GameObject> OnMinigameWin;
    private GameObject _fixingTile;

    private void OnEnable()
    {
        foreach (var item in _qteKeys)
        {
            item.KeyCode.Enable();
        }
    }
    public void StartQte(GameObject tile)
    {
        _fixingTile = tile;
        
        _combinationType = (CombinationType)Random.Range(0, 3);
        _multiplier = Random.Range(1, 20);
        ChooseRandomButtons();
        
        isChecking = true;
    }
    
    private void ChooseRandomButtons()
    {
        _keysSelected.Clear();
        for (var i = 0; i < 3; i++)
        {
            var random = Random.Range(0, _qteKeys.Count);
            _keysSelected.Add(_qteKeys[random]);
        }

        SetButtonNames();
    }

    private void SetButtonNames()
    {
        foreach (var item in _keysSelected)
        {
            var buttonCode = item.KeyCode.bindings[0].effectivePath;
            var splitCode = buttonCode.Split('/');
            item.ButtonName = splitCode[1];
        }
    }
    private void Update()
    {
        if (!isChecking)
            return;
        switch (_combinationType)
        {
            case CombinationType.Single:
                _keysSelected[0].KeyCode.started += context => 
                    Success();
                break;
            case CombinationType.Dual:
                if ((_keysSelected[0].KeyCode.triggered && _keysSelected[1].KeyCode.inProgress) || (_keysSelected[0].KeyCode.inProgress && _keysSelected[1].KeyCode.triggered))
                    Success();
                break;
            case CombinationType.Triple:
                if ((_keysSelected[0].KeyCode.triggered && _keysSelected[1].KeyCode.inProgress && _keysSelected[2].KeyCode.inProgress) || 
                    (_keysSelected[0].KeyCode.inProgress && _keysSelected[1].KeyCode.triggered && _keysSelected[2].KeyCode.inProgress) ||
                    (_keysSelected[0].KeyCode.inProgress && _keysSelected[1].KeyCode.inProgress && _keysSelected[2].KeyCode.triggered))
                    Success();
                break;
        }
    }

    private void Success()
    {
        if (_multiplier == 0)
        {
            isChecking = false;
            Win();
            return;
        }

        _multiplier--;
    }

    private void Win()
    {
        OnMinigameWin.Invoke(_fixingTile);
    }
    private void OnDisable()
    {
        foreach (var item in _qteKeys)
        {
            item.KeyCode.Disable();
        }
    }
}
