using UnityEngine;

public class moveCamera : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Vector3 _startPosition;
    
    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        var delta = Time.deltaTime * _moveSpeed;
        transform.position += new Vector3(delta, 0, 0);
        if (transform.position.x >= 240)
        {
            transform.position = _startPosition;
        }
    }
}
