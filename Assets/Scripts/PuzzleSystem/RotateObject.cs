using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class RotateObject : MonoBehaviour
{
    private Vector3 _currentRotation;
    private Tween _tween;
    [SerializeField] public UnityEvent OnConntectionReset;

    private void Awake()
    {
        _tween = transform.DOMove(transform.position, 0.1f);
    }

    public void RotateOnInput()
    {
        OnConntectionReset.Invoke();
        _currentRotation = transform.eulerAngles;
        switch (_currentRotation.y)
        {
            case >= 0 and < 90:
                Rotate(90);
                break;
            case >= 90 and < 180:
                Rotate(180);
                break;
            case >= 180 and < 270:
                Rotate(270);
                break;
            case >= 270 and < 360:
                Rotate(0);
                break;
        }
    }
    private void Rotate(int rotation)
    {
        var targetRotation = new Vector3(_currentRotation.x, rotation, _currentRotation.z);
        if (_tween.active)
            return;
        _tween = transform.DORotate(targetRotation, 3f);
    }
}
