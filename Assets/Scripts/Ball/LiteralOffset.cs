using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiteralOffset : MonoBehaviour
{
    [SerializeField] private Inputing _inputing;
    [SerializeField] private float _literalSpeed;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;

    private Vector3 _next;
    private float _currentX;

    private void Update()
    {
        _next = transform.position;
        _currentX = _next.x;
        _currentX += _inputing.DeltaTouchX;
        _currentX = Mathf.Clamp(_currentX, _minX, _maxX);
        _next.x = _currentX;
        transform.position = Vector3.MoveTowards(transform.position, _next, _literalSpeed * Time.deltaTime);
    }
}
