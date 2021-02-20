using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class Garbage : MonoBehaviour
{
    [SerializeField] private float _weight;

    private Collider _collider;
    private RayfireShatter _shatter;

    public Rigidbody Rigidbody { get; private set; }

    private void Start()
    {
        _collider = GetComponent<Collider>();
        Rigidbody = GetComponent<Rigidbody>();
        _shatter = GetComponent<RayfireShatter>();
    }

    public virtual void OnTriggWithBall()
    {
        _collider.isTrigger = true;
        Rigidbody.isKinematic = true;
    }
}
