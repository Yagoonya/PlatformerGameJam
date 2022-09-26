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

        public IEnumerator DoPatrol()
        {
            while (enabled)
            {
                if (_platformChecker.IsTouchingLayer && !_obstacleChecker.IsTouchingLayer)
                {
                    _charcter.SetDirection(new Vector2(_direction, 0));
                }
                else
                {
                    _charcter.SetDirection(Vector2.zero);
                    _animator.SetBool(Blink, true);
                    _direction = -_direction;
                    yield return new WaitForSeconds(1.7f);
                    _charcter.transform.localScale = new Vector3(_direction, 1, 1);
                    _animator.SetBool(Blink, false);
                }

                yield return null;
            }
        }
    }
}