using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputing : MonoBehaviour
{
    private float _lastTouchX;

    private bool _haveClick;

    public float DeltaTouchX { get; private set; }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _lastTouchX = Input.mousePosition.x;
            _haveClick = true;
        }

        if(Input.GetMouseButtonUp(0))
        {
            _haveClick = false;
            DeltaTouchX = 0;
        }

        if (_haveClick)
        {
            if (Input.GetMouseButton(0))
            {
                DeltaTouchX = Input.mousePosition.x - _lastTouchX;
            }
        }

    }
}
