using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Inputing _inputing;
    [SerializeField] private BallData _ballData;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;

    private float _literalSpeed;
    private float _speed;

    private Vector3 _next;
    private Vector3 _forwardMoving;
    private float _currentX;

    private void Update()
    {
        _literalSpeed = _ballData.LiteralSpeed;
        _speed = _ballData.ForwardSpeed;

        _next = transform.position;
        _currentX = _next.x;
        _currentX += _inputing.DeltaTouchX;
        _currentX = Mathf.Clamp(_currentX, _minX, _maxX);
        _next.x = _currentX;
        transform.position = Vector3.MoveTowards(transform.position, _next, _literalSpeed * Time.deltaTime);
        MoveForward();
    }

    private void MoveForward()
    {
        _forwardMoving = _speed * transform.forward;
        transform.Translate(_forwardMoving * Time.deltaTime);
    }
}
