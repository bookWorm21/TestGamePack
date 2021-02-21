using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new ball", menuName = "Create ball" , order = 51)]
public class BallData : ScriptableObject
{
    [SerializeField] private int _startWeight;
    [SerializeField] private int _weightForSizeUp;
    [SerializeField] private float _impulse;
    [SerializeField] private Vector3 _deltaScale;

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _literalSpeed;
    [SerializeField] private float _forwardSpeed;

    public int StartWeight => _startWeight;

    public int WeightForSizeUp => _weightForSizeUp;

    public float Impulse => _impulse;

    public Vector3 DeltaScale => _deltaScale;

    public float RotationSpeed => _rotationSpeed;

    public float LiteralSpeed => _literalSpeed;

    public float ForwardSpeed => _forwardSpeed;
}
