using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace Characters.Enemies
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private LayerCheck _platformChecker;
        [SerializeField] private LayerCheck _obstacleChecker;
        [SerializeField] private Character _charcter;
        [SerializeField] private int _direction;

        private Animator _animator;

        private static readonly int Blink = Animator.StringToHash("Is-Blinking");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            StartCoroutine(DoPatrol());
        }
        
        

        private IEnumerator DoPatrol()
        {
            while (enabled)
            {
                if (_platformChecker.IsTouchingLayer && !_obstacleChecker.IsTouchingLayer)
                {
                    _charcter.SetDirection(new Vector2(_direction, 0));
                }
                else
                {
                    _direction = -_direction;
                    _charcter.SetDirection(new Vector2(_direction, 0));
                }
                
                yield return null;
            }
        }
    }
}