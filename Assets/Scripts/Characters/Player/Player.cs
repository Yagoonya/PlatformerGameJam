using System;
using UnityEngine;
using Utils;

namespace Characters.Player
{
    public class Player : Character
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _attackRange;
        [SerializeField] private LayerMask _enemyLayers;
        [SerializeField] private Collider2D _lightCheck;
        
        private SpriteRenderer _sprite;

        private Color _default;
        
        protected override void Awake()
        {
            base.Awake();
            _sprite = GetComponent<SpriteRenderer>();
            _default = _sprite.color;
        }

        public void DoAttack()
        {
            Animator.SetTrigger(Attack);
        }

        public void SetInvisible()
        {
            _sprite.color = new Color(1f,1f,1f, 0.5f);
            _lightCheck.enabled = false;
            Invoke(nameof(ResetToDefault), 2f);
        }

        private void ResetToDefault()
        {
            _sprite.color = _default;
            _lightCheck.enabled = true;
        }

        public void Check()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);

            foreach (var enemy in hitEnemies)
            {
               var mortal = enemy.GetInterface<IMortal>();
                mortal.Dead();
            }
        }
        
        
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(_attackPoint.position,  _attackRange);
        } 
#endif
    }
}