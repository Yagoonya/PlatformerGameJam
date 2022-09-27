using System.Collections;
using UnityEngine;

public class BigLightBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveTime = 10f;

    private void Start()
    {
        StartCoroutine(MoveAnimation());
        Destroy(gameObject,8f);
    }

    private IEnumerator MoveAnimation()
    {            
        var moveTime = 0f;
        while (moveTime < _moveTime)
        {
            moveTime += Time.deltaTime;
            var progress = moveTime / _moveTime;
            transform.position = Vector3.Lerp(transform.position, _target.position, progress);

            yield return null;
        }
    }
    
}
