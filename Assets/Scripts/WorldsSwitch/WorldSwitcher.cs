using UnityEngine;
using Utils;

namespace WorldsSwitch
{
    public class WorldSwitcher : MonoBehaviour
    {
        [SerializeField] private World _world1;
        [SerializeField] private World _world2;
        
        private bool _isWorld1Active;

        private void Awake()
        {
            if (IsSwitcherExist())
            {
                Destroy(gameObject);
            }
            SwitchWorld();
        }
        
        
        [ContextMenu("Switch World")]
        public void SwitchWorld()
        {
            EventManager.OnWorldChanged();
            
            if (_isWorld1Active)
            {
                _world1.SwitchActivity(false);
                _world2.SwitchActivity(true);
                _isWorld1Active = !_isWorld1Active;
            }
            else
            {
                _world1.SwitchActivity(true);
                _world2.SwitchActivity(false);
                _isWorld1Active = !_isWorld1Active;
            }
        }

        private bool IsSwitcherExist()
        {
            var switchers = FindObjectsOfType<WorldSwitcher>();
            foreach (var switcher in switchers)
            {
                if (switcher != this)
                {
                    return true;
                }
            }

            return false;
        }
    }
}