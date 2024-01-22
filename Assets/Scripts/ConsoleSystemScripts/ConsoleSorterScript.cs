using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ConsoleSorterScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private List<GameObject> _textLines;
    [SerializeField] private GameObject _userTextPrefab;
    [SerializeField] private GameObject _consoleTextPrefab;

    public void SpawnTextLine()
    {
        var inputTxt = _inputField.text;
        SpawnUserText();
        
        SpawnConsoleText(inputTxt);
        
        _inputField.ActivateInputField();
    }

    private void SpawnUserText()
    {
        var spawnedTxt = Instantiate(_userTextPrefab, this.transform);
        spawnedTxt.GetComponent<TMP_Text>().text = _inputField.text;
        ControlSpaceOnConsole(spawnedTxt);
        _inputField.text = "";
    }

    private void SpawnConsoleText(string inputTxt)
    {
        var consoleTxt = Instantiate(_consoleTextPrefab, this.transform);
        var response = "";
        var tmpText = consoleTxt.GetComponent<TMP_Text>();
        
        tmpText.color = Color.green;
        switch (inputTxt)
        {
            case "camera.hack":
                response = "camera hacked successfully";
                break;
            case "camera.unlock":
                response = "camera unlocked successfully";
                break;
            case "fuck you":
                response = "no, fuck you!";
                break;
            default:
                response = "command not recognized";
                tmpText.color = Color.red;
                break;
        }

        tmpText.text = response;
        
        
        ControlSpaceOnConsole(consoleTxt);
    }
    private void ControlSpaceOnConsole(GameObject txt)
    {
        if (_textLines.Count <= 13)
        {
            _textLines.Add(txt);
        }
        else
        {
            Destroy(_textLines[0]);
            _textLines.Remove(_textLines[0]);
            _textLines.Add(txt);
        }
    }
}