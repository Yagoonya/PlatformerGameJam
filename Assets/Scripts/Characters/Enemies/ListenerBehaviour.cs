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

        private IEnumerator _current;

        private void Awake()
        {
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
            StartState(Scream());
        }

        private IEnumerator Scream()
        {
            //проиграть анимацию
            //подождать конца анимации
            _action?.Invoke();
            yield return new WaitForSeconds(10f);
            
            StartState(_patrol.DoPatrol());
        }
    }
}