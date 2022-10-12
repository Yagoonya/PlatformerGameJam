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

        [SerializeField] private GameObject _mainMusic;
        [SerializeField] private GameObject _bossMusic;

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
            yield return LightAnimation(0.45f,0f, 0.75f,_worldLight);
            yield return new WaitForSeconds(3f);
            yield return LightAnimation(0f,0.3f, 10f, _bossFightLight);
            StartState(DoAttack());
        }

        private IEnumerator LightAnimation(float start, float end, float _time, Light2D light)
        {
            var time = 0f;

            while (time < _time)
            {
                time += Time.deltaTime;
                var progress = time / _time;
                var temp = Mathf.Lerp(start, end, progress);
                light.intensity = temp;
                yield return null;
            }
        }

        private void DoAttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }

        private IEnumerator DoAttack()
        {
            while (!_isFightEnd)
            {
                _tentacleSpawner.Spawn();
                yield return _tentacleSpawner.TentacleMovement();
                DoAttackAnimation();
                yield return new WaitForSeconds(_tentacleSpawner.TentacleTime);
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
            _bossMusic.SetActive(false);
            _mainMusic.SetActive(true);
            _isFightEnd = false;
            StopAllCoroutines();
            _worldLight.intensity = 0.45f;
            _bossFightLight.intensity = 0f;
        }
    }
}