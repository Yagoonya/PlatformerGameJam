using UnityEngine;

namespace Utils
{
    public class DisableLight : DisableObject
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private SpriteRenderer _sprite;
        
        public override void SetActivate(bool value)
        {
            _collider.enabled = value;
            _sprite.enabled = value;
        }
    }
}