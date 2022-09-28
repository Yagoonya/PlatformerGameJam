using UnityEngine;
using UnityEngine.Events;

namespace Characters.Enemies.Boss
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] public UnityEvent _onDie;

        public int MaxHealth => _health;

        public void ApplyChange(int changingValue)
        {
            if (_health <= 0) return;

            if (_health > 0)
            {
                _health += changingValue;
                Debug.Log($"Всего здоровья {_health} у {gameObject.name}");
            }

            if (changingValue < 0)
            {
                _onDamage?.Invoke();
            }

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }

        public void SetHealth(int value)
        {
            if (value <= 0) return;
            _health = value;
        }

        private void OnDestroy()
        {
            _onDie.RemoveAllListeners();
        }
    }
}