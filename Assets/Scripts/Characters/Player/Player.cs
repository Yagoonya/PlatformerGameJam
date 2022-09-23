using Scripts.Utils;
using UnityEngine;


namespace Scripts.Characters.Player
{
    public class Player : MonoBehaviour
    {
        [Range(0, 10)] [SerializeField] private float _speed;
        [Range(0, 10)] [SerializeField] private float _jumpForce;

        [SerializeField] private ColliderCheck _groundCheck;

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Death = Animator.StringToHash("Death");

        private Vector2 _direction;
        private Rigidbody2D _rigidbody;
        private bool _isGrounded;
        private Animator _animator;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
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
        }
    }
}