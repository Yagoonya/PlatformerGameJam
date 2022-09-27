using System.Collections;
using UnityEngine;

namespace Characters.Enemies
{
    public class BlinkingLight : LightComponent
    {
        [SerializeField] private bool _isBlinking;
        [SerializeField] private float _blinkDuration;

        private void Start()
        {
            StartCoroutine(SwitchLight());
        }
        
        private void OnEnable()
        {
            StartCoroutine(SwitchLight());
        }
        
        private void OnDisable()
        {
            StopCoroutine(SwitchLight());
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
}