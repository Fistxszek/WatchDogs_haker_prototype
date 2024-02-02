using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrakeTiles : MonoBehaviour
{
    private void Start()
    {
        var childCount = transform.childCount;
        var numberOfBrakes = Random.Range(2, 5);

        var children = new List<GameObject>();
        for (int i = 0; i < numberOfBrakes; i++)
        {
            var randomChild = Random.Range(0, childCount);
            var child = transform.GetChild(randomChild);
            if (children.Contains(child.gameObject))
                i--;
            else
            {
                children.Add(child.gameObject);
                child.AddComponent<BrokenPuzzle>();
            }
        }
    }
}
