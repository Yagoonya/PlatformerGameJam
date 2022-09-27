using System;
using UnityEngine;

namespace Utils
{
    public class ParallaxComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [Range(0f, 1f)] [SerializeField] private float _parallaxStrenght = 0.1f;
        [SerializeField] private bool _disableVerticalParallax;

        private Vector3 _targetPreviousPosition;

        private void Start()
        {
            if (!_target)
                _target = Camera.main.transform;

            _targetPreviousPosition = _target.position;
        }

        private void Update()
        {
            var delta = _target.position - _targetPreviousPosition;

            if (_disableVerticalParallax)
                delta.y = 0;

            _targetPreviousPosition = _target.position;

            transform.position += delta * _parallaxStrenght;
        }
    }
}