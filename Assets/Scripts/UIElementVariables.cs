using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;   

public class UIElementVariables : MonoBehaviour
{
    [HideInInspector] public string ElementName;
    [HideInInspector] public Sprite ElementIcon;

    [SerializeField] private TMP_Text _nameInUI;
    [SerializeField] public Image _imageInUI;

    private void Start()
    {
        _nameInUI = FindObjectOfType<TMP_Text>();
        _imageInUI = FindObjectOfType<Image>();
        
        _nameInUI.text = ElementName;
        _imageInUI.sprite = ElementIcon;
    }
}
