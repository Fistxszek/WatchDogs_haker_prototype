using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SingleInputController : MonoBehaviour
{
    [SerializeField] private InputActionReference inputAction;
    [SerializeField] private UnityEvent attachedKeyDown;
    private void OnEnable()
    {
        inputAction.action.performed += OnInputPerformed;
    }

    private void OnDisable()
    {
        inputAction.action.performed -= OnInputPerformed;
    }

    private void OnInputPerformed(InputAction.CallbackContext context)
    {
        attachedKeyDown?.Invoke();
    }
}