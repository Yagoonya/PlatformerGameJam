using UnityEngine;

namespace WorldsSwitch
{
    public class World : MonoBehaviour
    {
        [SerializeField] public GameObject _enviroments;
        [SerializeField] public GameObject _obstackles;
        
        public void SwitchActivity(bool value)
        {
            _enviroments.SetActive(value);
            _obstackles.SetActive(value);
        }
        
    }
}