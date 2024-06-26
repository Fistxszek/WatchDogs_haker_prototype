using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public enum PipeType
{
    Straight,
    Elbow,
    Tee,
    Cross,
    Broken
}
public class PuzzleTileFace : MonoBehaviour
{
    [Header("Components")]
    private Renderer _renderer;
    private MeshRenderer _meshRenderer;
    
    [Header("Materials"), SerializeField]
    private Material[] _linesMaterials = new Material[4];
    [Header("Pipes variants"), SerializeField] 
    private GameObject[] _pipesVariants;
    private int _variant;

    [SerializeField] private Material[] _activeMaterialsArray;
    private Material _activeMaterial;
    private Material _material;
    
    [Header("Colliders"), SerializeField]
    private GameObject[] _collidersList;

    [Space(10), Header("3D or Easy mode")]
    private bool _easyMode;
    
    [Header("Lines Look")]
    [SerializeField] public PipeType PipeTypeEnum;
    private bool _isConnectedTop;
    private bool _isConnectedBottom;
    private bool _isConnectedLeft;
    private bool _isConnectedRight;

    private SetPipeActive _choosedPipe;

    [HideInInspector] public bool IsBroken;
    [SerializeField] public GameObject selectedGameObject;
    public Sprite UIFaceImage;

    private void Awake()
    {
        _renderer = this.GetComponent<Renderer>();
        var puzzleController = FindObjectOfType<PuzzleController>();

        _easyMode = !puzzleController.IsPuzzle3D;
        SetTileFace();
    }

    public void ActiveMaterial(bool state)
    {
        switch (_easyMode)
        {
            case true: 
                if (state)
                    _renderer.material = _activeMaterial;
                else
                    _renderer.material = _material;
                break;
            case false:
                _choosedPipe.SetActivePipe(state);
                break;
        }
        
    }
    
    public void SetTileFace()
    {
        _isConnectedTop = false;
        _isConnectedBottom = false;
        _isConnectedLeft = false;
        _isConnectedRight = true;
        
        switch (PipeTypeEnum)
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
            case PipeType.Broken:
                SetBrokenFace();
                break;
        }
    }

    private void SetBrokenFace()
    {
        if (_easyMode)
        {
            _material = _linesMaterials[(int)PipeType.Broken];
        }
        else
        {
            _variant = 4;
        }
        SetFace(false,false,false,false);
    }
    private void SetStraightFace()
    {
        if (_easyMode)
        {
            _material = _linesMaterials[(int)PipeType.Straight];
            _activeMaterial = _activeMaterialsArray[0];
        }
        else
        {
            _variant = 0;
        }
        SetFace(true,true,false,false);
    }

    private void SetElbowFace()
    {
        if (_easyMode)
        {
            _material = _linesMaterials[(int)PipeType.Elbow];
            _activeMaterial = _activeMaterialsArray[1];
        }
        else
        {
           _variant = 1;
        }
        SetFace(false,true,false,true);
    }
    private void SetTeeFace()
    {
        if (_easyMode)
        {
            _material = _linesMaterials[(int)PipeType.Tee];
            _activeMaterial = _activeMaterialsArray[2];
        }
        else
        {
            _variant = 2;
        }
        SetFace(true,true,false,true);
    }
    private void SetCrossFace()
    {
        if (_easyMode)
        {
            _material = _linesMaterials[(int)PipeType.Cross];
            _activeMaterial = _activeMaterialsArray[3];
        }
        else
        {
            _variant = 3;
        }
        SetFace(true,true,true,true);
    }

    private void SetFace(bool top, bool bottom, bool left, bool right)
    {
        _isConnectedTop = top;
        _isConnectedBottom = bottom;
        _isConnectedLeft = left;
        _isConnectedRight = right;
        
        if (!_renderer)
            return;
        
        if (_easyMode)
        {
            SetVariant(9);
            _renderer.enabled = true;
            _renderer.material = _material;
        }
        else
        {
            _renderer.enabled = false;
            SetVariant(_variant);
        }
        
        SetColliders(top, bottom, left, right);
    }

    private void SetColliders(bool top, bool bottom, bool left, bool right)
    {
        _collidersList[0].SetActive(top);
        _collidersList[1].SetActive(bottom);
        _collidersList[2].SetActive(left);
        _collidersList[3].SetActive(right);
    }

    private void SetVariant(int num)
    {
        for (int i = 0; i < _pipesVariants.Length; i++)
        {
            if (i != num)
                _pipesVariants[i].SetActive(false);
            else
            {
                _pipesVariants[num].SetActive(true);
                _choosedPipe = _pipesVariants[num].GetComponent<SetPipeActive>();
            }
        }
    }
}
