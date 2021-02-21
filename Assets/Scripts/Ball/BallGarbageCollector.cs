using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGarbageCollector : MonoBehaviour
{
    [SerializeField] private BallData _ballData;
    [SerializeField] private Transform _rotatingParent;

    [SerializeField] private Transform _mainRoot;
    [SerializeField] private Transform _cameraTargetTransform;
    [SerializeField] private GameObject _ballMesh;
    [SerializeField] private SphereCollider _collector;

    private float _impulse;
    private int _startWeight;
    private int _weightForSizeUp;
    private Vector3 _deltaScale;

    private int _weight;
    private int _currentNeedWeight;
    private int _sizeLevel;

    public System.Action<int> ChangedWeight;

    private void Start()
    {
        _weight = _ballData.StartWeight;
        _impulse = _ballData.Impulse;
        _deltaScale = _ballData.DeltaScale;
        _weightForSizeUp = _ballData.WeightForSizeUp;

        _startWeight = _weight;

        _weight = _startWeight;
        _sizeLevel = 1;
        _currentNeedWeight = _sizeLevel * _weightForSizeUp;
        ChangedWeight?.Invoke(_weight - _startWeight);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Garbage garbage))
        {
            if (_weight > garbage.Weight)
            {
                _weight += garbage.Weight;
                ChangedWeight?.Invoke(_weight - _startWeight);
                garbage.transform.parent = transform;
                garbage.OnTriggWithBall();

                if (_weight >= _currentNeedWeight)
                {
                    SizeUp();
                }
            }
            else
            {
                garbage.Crash(transform, _impulse);
            }
        }
    }

    private void SizeUp()
    {
        StartCoroutine(IncreazeSize());
    }

    private IEnumerator IncreazeSize()
    {
        while (_weight >= _currentNeedWeight)
        {
            float lastScale = _ballMesh.transform.localScale.x;

            _sizeLevel++;

            _currentNeedWeight = _sizeLevel * _weightForSizeUp;
            _collector.radius += _deltaScale.x * 0.5f;
            _ballMesh.transform.localScale += _deltaScale;

            _cameraTargetTransform.transform.localPosition *= (lastScale + _deltaScale.x * 0.65f) / lastScale;

            Vector3 rootPosition = _mainRoot.transform.position;
            rootPosition.y += _deltaScale.x / 2;
            _mainRoot.position = rootPosition;
            yield return new WaitForSeconds(1.1f);
        }
    }
}
