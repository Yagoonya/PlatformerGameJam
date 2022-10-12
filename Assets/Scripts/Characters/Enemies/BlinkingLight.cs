using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Characters.Enemies
{
    public class BlinkingLight : LightComponent
    {
        [SerializeField] private bool _isBlinking;
        [SerializeField] private float _blinkDuration;

        [SerializeField] private Light2D _attentionLight;

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
                    _attentionLight.intensity = 0f;
                    yield return LightAnimation();
                    _collider.enabled = true;
                    _sprite.enabled = true;
                }
                yield return new WaitForSeconds(_blinkDuration);
            }
        }

        private IEnumerator LightAnimation()
        {
            var time = 0f;

            while (time < _blinkDuration)
            {
                time += Time.deltaTime;
                var progress = time / _blinkDuration;
                var temp = Mathf.Lerp(0, 1, progress);
                _attentionLight.intensity = temp;
                yield return null;
            }
        }
    }
}