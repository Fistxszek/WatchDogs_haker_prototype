using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class ConsoleVisibility : MonoBehaviour
{
    [SerializeField] private GameObject _consoleCanvas;
    [SerializeField] private GameObject _cursorController;
    [SerializeField] private FirstPersonController FirstPersonController;
    public bool isActive;

    public void ChangeVisibility()
    {
        _consoleCanvas.SetActive(!isActive);
        _cursorController.SetActive(!isActive);
        isActive = !isActive;
        ChangeLockMovement();
    }

    private void ChangeLockMovement()
    {
        //FirstPersonController.isLocked = !FirstPersonController.isLocked;
    }

}
