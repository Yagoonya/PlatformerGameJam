﻿using UnityEngine;
using Utils;

namespace Characters
{
    public class Character : MonoBehaviour, IMortal
    {
        [Range(0, 10)] [SerializeField] private float _speed;
        [Range(0, 10)] [SerializeField] private float _jumpForce;
        
        [SerializeField] private ColliderCheck _groundCheck;
        [SerializeField] private bool _invertScale;
        
        private static readonly int Death = Animator.StringToHash("Death");
        
        private bool _isGrounded;
        private Vector2 _direction;
        private Rigidbody2D _rigidbody;
        
        protected Animator Animator;
        
        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
        }
        
        private void Update()
        {
            _isGrounded = _groundCheck.IsTouchingLayer;
        }
        
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private  float CalculateJumpVelocity(float yVelocity)
        {
            if (_isGrounded)
            {
                yVelocity = _jumpForce;
            }

            return yVelocity;
        }
        
        private  float CalculateYVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;
            var isJumpPressing = _direction.y > 0;

            if (isJumpPressing)
            {
                var isFalling = _rigidbody.velocity.y <= 0.001f;
                yVelocity = isFalling ? CalculateJumpVelocity(yVelocity) : yVelocity;
            }
            return yVelocity;
        }

        private void FixedUpdate()
        {
            var xVelocity = _direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

            UpdateSpriteDirection(_direction);
        }

        public void Dead()
        {
            Animator.SetTrigger(Death);
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }
        
        private void UpdateSpriteDirection(Vector2 direction)
        {
            var multiplier = _invertScale ? -1 : 1;
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(multiplier, 1, 1);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1 * multiplier, 1, 1);
            }
        }
    }
}