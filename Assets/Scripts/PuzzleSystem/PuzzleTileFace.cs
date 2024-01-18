using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PipeType
{
    Straight,
    Elbow,
    Tee,
    Cross
}
[ExecuteAlways]
public class PuzzleTileFace : MonoBehaviour
{
    [Header("Components"), SerializeField]
    private Renderer _renderer;
    
    [Header("Materials")] [SerializeField]
    private Material[] _linesMaterials = new Material[4];

    [SerializeField] private Material[] _activeMaterialsArray;
    private Material _activeMaterial;
    private Material _material;
    
    [Header("Colliders"), SerializeField]
    private GameObject[] _collidersList;
    
    [Header("Lines Look")]
    [SerializeField] private PipeType _pipeType;
    private bool _isConnectedTop;
    private bool _isConnectedBottom;
    private bool _isConnectedLeft;
    private bool _isConnectedRight;

    public void ActiveMaterial(bool state)
    {
        if (state)
            _renderer.material = _activeMaterial;
        else
            _renderer.material = _material;
    }
    public void SetTileFace()
    {
        _isConnectedTop = false;
        _isConnectedBottom = false;
        _isConnectedLeft = false;
        _isConnectedRight = true;
        
        switch (_pipeType)
        {
            case PipeType.Straight:
                SetStraightFace();
                break;
            case PipeType.Elbow:
                SetElbowFace();
                break;
            case PipeType.Tee:
                SetTeeFace();
                break;
            case PipeType.Cross:
                SetCrossFace();
                break;
        }
    }

    private void SetStraightFace()
    {
        _material = _linesMaterials[(int)PipeType.Straight];
        SetFace(true,true,false,false);
        _activeMaterial = _activeMaterialsArray[0];
    }

    private void SetElbowFace()
    {
        _material = _linesMaterials[(int)PipeType.Elbow];
        SetFace(false,true,false,true);
        _activeMaterial = _activeMaterialsArray[1];
    }
    private void SetTeeFace()
    {
        _material = _linesMaterials[(int)PipeType.Tee];
        SetFace(true,true,false,true);
        _activeMaterial = _activeMaterialsArray[2];
    }
    private void SetCrossFace()
    {
        _material = _linesMaterials[(int)PipeType.Cross];
        SetFace(true,true,true,true);
        _activeMaterial = _activeMaterialsArray[3];
    }

    private void SetFace(bool top, bool bottom, bool left, bool right)
    {
        _isConnectedTop = top;
        _isConnectedBottom = bottom;
        _isConnectedLeft = left;
        _isConnectedRight = right;

        _renderer.material = _material;
        
        SetColliders(top, bottom, left, right);
    }

    private void SetColliders(bool top, bool bottom, bool left, bool right)
    {
        _collidersList[0].SetActive(top);
        _collidersList[1].SetActive(bottom);
        _collidersList[2].SetActive(left);
        _collidersList[3].SetActive(right);
    }
    private void OnValidate()
    {
        SetTileFace();
    }
}
