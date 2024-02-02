using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public GameObject SelectedTilesUI;
    [SerializeField] private GameObject _uiElementPrefab;

    private List<GameObject> _uiElementsList = new List<GameObject>();

    public void AddSelectedToUI(string name, Sprite icon)
    {
        var spawnedElement = Instantiate(_uiElementPrefab, SelectedTilesUI.transform);
        var spawnedElementScript = spawnedElement.AddComponent<UIElementVariables>();

        spawnedElementScript.ElementName = name;
        spawnedElementScript.ElementIcon = icon;
        
        _uiElementsList.Add(spawnedElement);
    }

    public void RemoveSelectedFromUI(int index)
    {
        Destroy(_uiElementsList[index]);
        _uiElementsList.Remove(_uiElementsList[index]);
    }
}
