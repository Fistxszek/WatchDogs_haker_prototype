using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImageLookAtPlayerInCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Awake()
    {
        var mainCam = FindObjectOfType(typeof(Camera));
        target = mainCam.GetComponent<Transform>();
    }

    void Update()
    {
        transform.LookAt(target);
    }
}
