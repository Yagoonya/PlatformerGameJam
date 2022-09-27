using UnityEngine;

namespace Utils
{
    public class SpawnPrefab : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Cooldown _cooldown;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            if (_cooldown.IsReady)
            {
                var instantiate = Instantiate(_prefab, _target.position, Quaternion.identity);
                var scale = _target.lossyScale;
                instantiate.transform.localScale = scale;
                instantiate.SetActive(true);
                _cooldown.Reset();
            }
        }
    }
}