using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace Characters.Enemies.Boss
{
    public class TentacleSpawner : MonoBehaviour
    {
        [SerializeField] private TentaclePoint[] _points;
        [SerializeField] private Transform _tentacle;
        [SerializeField] private CircleCollider2D _hitCollider;
        [SerializeField] private float _tentcleTime;
        [SerializeField] private float _timerOn;
        [SerializeField] private float _timerOff;
        [SerializeField] private playSounds _tentacleSounds;

        private int randomPoint;
        private IEnumerator _current;

        public float TentacleTime => _tentcleTime;
        
        [ContextMenu("SetPosition")]
        public void Spawn()
        {
            randomPoint = Random.Range(0, _points.Length);
            var localX = randomPoint % 2 != 0 ? -1 : 1;
            _tentacle.localScale = new Vector3(localX, 1, 1);
            _tentacleSounds.Play("attack");
            _tentacle.position = _points[randomPoint]._startPos.position;
            
            StartCoroutine(TentacleMovement());
        }

        public IEnumerator TentacleMovement()
        {
            StartState(Move(_tentacle, _points[randomPoint]._endPos,_timerOn));
            _hitCollider.enabled = true;
            yield return new WaitForSeconds(_tentcleTime/2.5f);
            _hitCollider.enabled = false;
            yield return new WaitForSeconds(_tentcleTime/2f);
            StartState(Move(_tentacle, _points[randomPoint]._startPos, _timerOff));
            yield return new WaitForSeconds(_tentcleTime);
        }
        
        private void StartState(IEnumerator coroutine)
        {
            if (_current != null)
                StopCoroutine(_current);

            _current = coroutine; 
            StartCoroutine(coroutine);
        }
        
        private IEnumerator Move(Transform start, Transform end, float _timer)
        {
            var moveTime = 0f;
            while (moveTime < _timer)
            {
                moveTime += Time.deltaTime;
                var progress = moveTime / _timer;
                _tentacle.position = Vector3.Lerp(start.position, end.position, progress);
                 yield return null;
            }
        }
    }
    
}

[Serializable]
public class TentaclePoint
{
    public Transform _startPos;
    public Transform _endPos;
}