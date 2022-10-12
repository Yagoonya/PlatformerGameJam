using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcesing : MonoBehaviour
{
    private Volume _post;
    private LensDistortion _lens;
    private Bloom _bloom;

    private float _time = 0.25f;

    private void Awake()
    {
        _post = GetComponent<Volume>();
        _post.profile.TryGet(out _lens);
        _post.profile.TryGet(out _bloom);
    }

    [ContextMenu("Abob")]
    public void StartEffect()
    {
        StartCoroutine(LensAndBloom());
    }

    private IEnumerator EffectAnimation(float start, float end)
    {
        var time = 0f;

        while (time < _time)
        {
            time += Time.deltaTime;
            var progress = time / _time;
            var temp = Mathf.Lerp(start, end, progress);
            _lens.intensity.value = temp;
            _bloom.intensity.value = temp;
            yield return null;
        }
    }

    private IEnumerator LensAndBloom()
    {
        yield return EffectAnimation(0f, 1f);
        yield return EffectAnimation(1f, 0f);
    }
    
    
}
