using UnityEngine;

namespace Scripts.Utils
{
    public class ColliderCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;
        [SerializeField] private bool _isTouchingLayer;

        public bool IsTouchingLayer => _isTouchingLayer;
        
        private Collider2D _collider;
        
        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            _isTouchingLayer = _collider.IsTouchingLayers(_layer);
        }
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            _isTouchingLayer = _collider.IsTouchingLayers(_layer);
        }
    }
}

