using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private Vector3 _currentVelocity;

    private void Start()
    {
        //_currentVelocity = new Vector3(1, 1, 1).normalized * _speed;
    }

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _target.position, ref _currentVelocity, Time.deltaTime * 2, _speed);
    }
}
