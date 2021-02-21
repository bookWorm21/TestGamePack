using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsView : MonoBehaviour
{
    [SerializeField] private BallGarbageCollector _garbageCollector;
    [SerializeField] private Text _textForPoint;

    private void OnEnable()
    {
        _garbageCollector.ChangedWeight += OnWeightChange;
    }

    private void OnDisable()
    {
        _garbageCollector.ChangedWeight -= OnWeightChange;
    }

    private void OnWeightChange(int value)
    {
        _textForPoint.text = value.ToString();
    }
}
