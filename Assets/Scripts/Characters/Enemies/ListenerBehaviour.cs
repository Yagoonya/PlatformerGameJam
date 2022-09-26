using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Characters.Enemies
{
    public class ListenerBehaviour : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;
        
        private Patrol _patrol;
        private Character _creature;
        private Animator _animator;

        private IEnumerator _current;
        
        private static readonly int Warning = Animator.StringToHash("warining");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _creature = GetComponent<Character>();
            _patrol = GetComponent<Patrol>();
        }

        private void Start()
        {
            StartState(_patrol.DoPatrol());
        }

        private void StartState(IEnumerator coroutine)
        {
            _creature.SetDirection(Vector2.zero);

            if (_current != null)
                StopCoroutine(_current);

            _current = coroutine;
            StartCoroutine(coroutine);
        }

        public void MakeScream()
        {
            _animator.SetTrigger(Warning);
        }

        public void StartSummoning()
        {
            StartState(Scream());
        }

        private IEnumerator Scream()
        {
            yield return new WaitForSeconds(1f);
            _action?.Invoke();
            _animator.SetBool("is-walking", false);
            yield return new WaitForSeconds(10f);
            StartState(_patrol.DoPatrol());
        }
    }
}