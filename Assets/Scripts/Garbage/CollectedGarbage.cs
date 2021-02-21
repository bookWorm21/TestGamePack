using RayFire;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedGarbage : Garbage
{
    [SerializeField] private GameObject _splintersRoot;

    Rigidbody[] _childRigidbodies;

    public override void OnStartGame()
    {
        _childRigidbodies = _splintersRoot.GetComponentsInChildren<Rigidbody>();
    }

    public override void Crash(Transform ballPoint, float impulsePower)
    {
        _splintersRoot.SetActive(true);
        gameObject.SetActive(false);
        for (int i = 0; i < _childRigidbodies.Length; i++)
        {
            _childRigidbodies[i].AddForce((_childRigidbodies[i].transform.position - ballPoint.position).normalized * impulsePower, ForceMode.Impulse);
        }
    }
}
