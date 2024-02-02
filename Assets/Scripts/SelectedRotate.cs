using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class SelectedRotate : MonoBehaviour
{
    public void RotateMultipleObjects()
    {
        var selectedList = GetComponentInParent<PuzzleController>().SelectedList;
        foreach (var item in selectedList)
        {
            item.GetComponentInParent<RotateObject>().RotateOnInput();
        }
    }
}
