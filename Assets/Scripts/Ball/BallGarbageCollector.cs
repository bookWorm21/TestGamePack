using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGarbageCollector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Garbage garbage))
        {
            garbage.transform.parent = transform;
            garbage.OnTriggWithBall();  
        }
    }
}
