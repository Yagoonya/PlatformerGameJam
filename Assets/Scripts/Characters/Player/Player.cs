using UnityEngine;
using Utils;

namespace Characters.Player
{
    public class Player : Character
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int HideIn = Animator.StringToHash("Is-Hidden");

        [SerializeField] private Transform _attackPoint;
        [SerializeField] private CheckCircleOverlap _atackRange;
        [SerializeField] private Transform _checkPoint;
        [SerializeField] private float _attackRange;
        [SerializeField] private LayerMask _enemyLayers;
        [SerializeField] private LayerMask _checkLayers;

        [SerializeField] private Cooldown _attackCooldown;

        private Vector2 _respawnPoint;

        private SpriteRenderer _sprite;
        private int _defaultLayer;
        private Color _default;
        
        private bool _isVisible = true;
        private bool _isDead;
        private bool _isHidden;

        public bool IsVisible => _isVisible;

        protected override void Awake()
        {
            base.Awake();
            _respawnPoint = transform.position;
            _sprite = GetComponent<SpriteRenderer>();
            _defaultLayer = gameObject.layer;
            _default = _sprite.color;
        }

        public void DoAttack()
        {
            if (!_isHidden && _attackCooldown.IsReady && IsDead != true)
            {
                Animator.SetTrigger(Attack);
                _attackCooldown.Reset();
            }
        }

        public void SwitchVisability()
        {
            if(_isVisible)
                Hide();
            else
                ResetToDefault();
        }

        public void HideInObject()
        {
            if (!_isHidden && IsInteractionExist() && IsDead != true)
            {
                _isHidden = true;
                Animator.SetBool(HideIn, true);
            }
            else
            {
                _isHidden = false;
                Animator.SetBool(HideIn, false);
            }
        }

        private void Hide()
        {
            _isVisible = false;
            _sprite.color = new Color(0.5f,0.5f,0.5f);
            gameObject.layer = 9;
        }

        public void ReloadAfterAnimation()
        {
            transform.position = _respawnPoint;
            IsDead = false;
            _isControllable = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Checkpoint"))
            {
                _respawnPoint = other.transform.position;
            }
        }

        private void ResetToDefault()
        {
            _isVisible = true;
            _sprite.color = _default;
            gameObject.layer = _defaultLayer;
        }

        public void Cover()
        {
            gameObject.layer = 14;
            _sprite.color = new Color(0.5f,0.5f,0.5f);
        }
        
        public void Uncover()
        {
            _sprite.color = _default;
            gameObject.layer = _defaultLayer;
        }

        private bool IsInteractionExist()
        {
            Collider2D[] hits = CheckOverlap(_checkPoint, _attackRange, _checkLayers);

            foreach (var hit in hits)
            {
                return true;
            }

            return false;
        }
        
        private Collider2D[] CheckOverlap(Transform transform, float range, LayerMask layer)
        {
             Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, layer);
             return hits;
        }

        public void Check()
        {
            _atackRange.Check();
            
            Collider2D[] hitEnemies = CheckOverlap(_attackPoint, _attackRange, _enemyLayers);

            foreach (var enemy in hitEnemies)
            {
               var mortal = enemy.GetInterface<IMortal>();
                mortal.Dead();
            }
        }
        
        public void SwitchControllability()
        {
            _isControllable = !_isControllable;
        }
        
        
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(_attackPoint.position,  _attackRange);
        } 
#endif
    }
}