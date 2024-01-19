using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetPipeActive : MonoBehaviour
{
    [SerializeField] private Material _pipeMaterial;
    [SerializeField] private Material _pipeActiveMaterial;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Renderer _renderer2;
    public void SetActivePipe(bool status)
    {
        if (status)
        {
            _renderer.material = _pipeActiveMaterial;
            if (_renderer2)
                _renderer2.material = _pipeActiveMaterial;
        }
        else
        {
            _renderer.material = _pipeMaterial;
            if (_renderer2)
                _renderer2.material = _pipeMaterial;
        }
    }
}
