using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Vector3 _normailziedRotationDirection;

    private void Update()
    {
        transform.Rotate(_normailziedRotationDirection * _rotationSpeed * Time.deltaTime);
    }
}
