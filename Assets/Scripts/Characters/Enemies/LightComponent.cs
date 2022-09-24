using System;
using System.Collections;
using UnityEngine;

public class LightComponent : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private bool _isBlinking;
    [SerializeField] private float _blinkDuration;

    private void Start()
    {
        StartCoroutine(SwitchLight());
    }

    private IEnumerator SwitchLight()
    {
        while (enabled)
        {
            if (_isBlinking)
            {
                _collider.enabled = false;
                _sprite.enabled = false;
                yield return new WaitForSeconds(_blinkDuration);
                _collider.enabled = true;
                _sprite.enabled = true;
            }
            yield return new WaitForSeconds(_blinkDuration);
        }
    }
}
