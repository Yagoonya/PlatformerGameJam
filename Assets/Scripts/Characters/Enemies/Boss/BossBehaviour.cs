using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Utils;

namespace Characters.Enemies.Boss
{
    public class BossBehaviour : MonoBehaviour
    {
        [SerializeField] private TentacleSpawner _tentacleSpawner;
        [SerializeField] private SpawnPrefab _lightSpawner;
        [SerializeField] private Light2D _bossFightLight;
        [SerializeField] private Light2D _worldLight;
        [SerializeField] private Health _tentacleHealthl;

        [SerializeField] private playSounds _bossSounds;

        private Health _bossHealth;
        
        private bool _isFightEnd = false;
        private IEnumerator _current;
        private Animator _animator;
        private int _healthStart;

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Death = Animator.StringToHash("Dead");

        private void Awake()
        {
            _bossHealth = GetComponent<Health>();
            _animator = GetComponent<Animator>();
            _healthStart = _bossHealth.MaxHealth;
        }

        [ContextMenu("StartBossFight")]
        public void StartBossFight()
        {
            _worldLight.intensity = 0f;
            StartCoroutine(StartFight());
        }

        private IEnumerator StartFight()
        {
            _bossHealth.SetHealth(_healthStart);
            _tentacleHealthl.SetHealth(_healthStart);
            _worldLight.intensity = Mathf.Lerp(0, 0.45f, 2500);
            _bossFightLight.intensity = Mathf.Lerp(0f, 0.2f, 2500);
            yield return new WaitForSeconds(6f);
            StartState(DoAttack());
        }

        private void DoAttackAnimatiom()
        {
            _animator.SetTrigger(Attack);
        }
        
        private IEnumerator DoAttack()
        {
            while (!_isFightEnd)
            {
                _tentacleSpawner.Spawn();
                yield return _tentacleSpawner.TentacleMovement();
                DoAttackAnimatiom();
                yield return new WaitForSeconds(_tentacleSpawner.TentacleTime * 1.5f);
            }
        }

        public void BossDead()
        {
            StopAllCoroutines();
            StartState(Dead());
            _bossSounds.Play("death");
            _isFightEnd = true;
            _animator.SetTrigger(Death);
        }

        private IEnumerator Dead()
        {
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }

        public void SpawnLight()
        {
            _lightSpawner.Spawn();
        }

        private void StartState(IEnumerator coroutine)
        {
            if (_current != null)
                StopCoroutine(_current);

            _current = coroutine;
            StartCoroutine(coroutine);
        }

        public void ResetBossFight()
        {
            _isFightEnd = false;
            StopAllCoroutines();
            _worldLight.intensity = 0.45f;
            _bossFightLight.intensity = 0f;
        }
    }
}