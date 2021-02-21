using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] private int _weight;

    private Collider _collider;
    protected Rigidbody _rigidbody;

    public int Weight => _weight;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        OnStartGame();
    }

    public virtual void OnTriggWithBall()
    {
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
    }

    public virtual void OnStartGame()
    {
        
    }

    public virtual void Crash(Transform ballPoint, float impulsePower)
    {
        _rigidbody.AddForce((transform.position - ballPoint.position).normalized * impulsePower, ForceMode.Impulse);
    }
}
