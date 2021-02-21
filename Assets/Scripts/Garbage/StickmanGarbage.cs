using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanGarbage : Garbage
{
    [SerializeField] private float _speed;
    [SerializeField] private Collider _mainCollider;
    [SerializeField] private Rigidbody _spineRigidbody;
    [SerializeField] private Animator _animator;

    private Rigidbody[] _childRigidbodies;
    private Collider[] _childColliders;

    private void Update()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime);
    }

    public override void Crash(Transform ballPoint, float impulsePower)
    {
        _speed = 0;
        _animator.enabled = false;
        _spineRigidbody.AddForce((transform.position - ballPoint.position).normalized * impulsePower, ForceMode.Impulse);
    }

    public override void OnTriggWithBall()
    {
        base.OnTriggWithBall();
        _animator.enabled = false;

        _rigidbody.isKinematic = true;
        enabled = false;
    }

    public override void OnStartGame()
    {
        _childRigidbodies = GetComponentsInChildren<Rigidbody>();
        _childColliders = GetComponentsInChildren<Collider>();

        for(int i = 0; i < _childRigidbodies.Length; i++)
        {
            _childRigidbodies[i].isKinematic = true;
        }

        for(int i = 0; i < _childColliders.Length; i++)
        {
            _childColliders[i].isTrigger = true;
        }

        _mainCollider.isTrigger = false;
        _rigidbody.isKinematic = false;
    }
}
