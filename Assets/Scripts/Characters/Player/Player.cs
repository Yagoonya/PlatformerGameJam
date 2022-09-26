using UnityEngine;
using Utils;
using WorldsSwitch;

namespace Characters.Player
{
    public class Player : Character
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int HideIn = Animator.StringToHash("Is-Hidden");

        [SerializeField] private Transform _attackPoint;
        [SerializeField] private Transform _checkPoint;
        [SerializeField] private float _attackRange;
        [SerializeField] private LayerMask _enemyLayers;
        [SerializeField] private LayerMask _checkLayers;
        [SerializeField] private ReloadLevel _reload;

        
        private SpriteRenderer _sprite;
        private int _defaultLayer;

        private WorldSwitcher _switcher;

        private Color _default;
        private bool _isVisible = true;
        private bool _isDead;
        private bool _isHidden;

        protected override void Awake()
        {
            base.Awake();
            _switcher = FindObjectOfType<WorldSwitcher>();
            _sprite = GetComponent<SpriteRenderer>();
            _defaultLayer = gameObject.layer;
            _default = _sprite.color;
        }

        public void DoAttack()
        {
            if(!_isHidden)
                Animator.SetTrigger(Attack);
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
            if (!_isHidden && IsInteractionExist())
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
            _sprite.color = new Color(1f,1f,1f, 0.5f);
            gameObject.layer = 9;
        }

        public void SwitchWorld()
        {
            _switcher.SwitchWorld();
        }

        public void ReloadAfterAnimation()
        {
            _reload.Reload();
        }

        private void ResetToDefault()
        {
            _isVisible = true;
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