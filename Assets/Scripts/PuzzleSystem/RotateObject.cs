using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class RotateObject : MonoBehaviour
{
    private Vector3 _currentRotation;
    private Tween _tween;
    [SerializeField] public UnityEvent OnConntectionReset;
    private float _rotationTime;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animation[] _animations;

    private void Awake()
    {
        var puzzleController = FindObjectOfType<PuzzleController>();
        
        _rotationTime = puzzleController.RotationObjectTime;
        _tween = transform.DOMove(transform.position, 0.1f);
        _animator.Play("rotate" + Random.Range(1,4).ToString());
    }

    public void RotateOnInput()
    {
        OnConntectionReset.Invoke();
        _currentRotation = transform.rotation.eulerAngles;

        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            return;
        _animator.SetTrigger("rotate"); 
        
    }
}
