using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInWorldCanvas : MonoBehaviour
{
    [SerializeField] public GameObject ObjectToShow;
    [SerializeField] public GameObject InactiveObjectToShow;
    private CameraActive _cameraActive;

    private void Awake()
    {
        _cameraActive = this.GetComponent<CameraActive>();
    }

    public void ShowObject()
    {
        if (_cameraActive.IsCameraActive)
        {
            ObjectToShow.SetActive(true);
            InactiveObjectToShow.SetActive(false);
        }
        else
        {
            InactiveObjectToShow.SetActive(true);
            ObjectToShow.SetActive(false);
        }
    }
    public void HideObject()
    {
        ObjectToShow.SetActive(false);
        InactiveObjectToShow.SetActive(false);
    }
}
