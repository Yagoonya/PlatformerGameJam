using UnityEngine;
using Utils;

namespace Characters.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private bool _isIn2ndWorld;

        private DisableObject _checker;
        private SpriteRenderer _sprite;
        private Color _default;
        private int _defaultLayer;


        private void Awake()
        {
            _checker = GetComponent<DisableObject>();
            _sprite = GetComponent<SpriteRenderer>();
            _defaultLayer = gameObject.layer;
            _default = _sprite.color;
            HideInOtherWorld();
        }

        private void Start()
        {
            EventManager.WorldChanged += HideInOtherWorld;
        }

        private void OnDestroy()
        {
            EventManager.WorldChanged -= HideInOtherWorld;
        }

        [ContextMenu("hide")]
        public void HideInOtherWorld()
        {
            if (_isIn2ndWorld)
            {
                Hide();
            }
            else
            {
                ResetToDefault();
            }
        }
        
        private void Hide()
        {
            _isIn2ndWorld = false;
            _sprite.color = new Color(1f,1f,1f, 0f);
            _checker.SetActivate(false);
            gameObject.layer = 13;
        }
            
        private void ResetToDefault()
        {
            _isIn2ndWorld = true;
            _sprite.color = _default;
            _checker.SetActivate(true);
            gameObject.layer = _defaultLayer;
        }
    }
}