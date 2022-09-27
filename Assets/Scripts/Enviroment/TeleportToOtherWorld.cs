using UnityEngine;
using WorldsSwitch;

namespace Enviroment
{
    public class TeleportToOtherWorld : MonoBehaviour
    {
        [SerializeField] private WorldSwitcher _switcher;

        public void Switch()
        {
            _switcher.SwitchWorld();
        }
    }
    
}