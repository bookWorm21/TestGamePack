using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotator : MonoBehaviour
{
    [SerializeField] private BallData _ballData;
    [SerializeField] private Vector3 _normailziedRotationDirection;

    private float _rotationSpeed;
    private Vector3 _rotation;

    private void Start()
    {
        _rotation = transform.eulerAngles;
        _rotationSpeed = _ballData.RotationSpeed;
    }

    private void Update()
    {
        _rotation += _rotationSpeed * _normailziedRotationDirection * Time.deltaTime;
        transform.eulerAngles = _rotation;
        //transform.Rotate(_normailziedRotationDirection * _rotationSpeed * Time.deltaTime);
    }
}
