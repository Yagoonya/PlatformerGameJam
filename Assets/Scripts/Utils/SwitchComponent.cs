using UnityEngine;

namespace Utils
{
    public class SwitchComponent : MonoBehaviour
    {
        private bool _isOn = true;

        public void SwitchLight()
        {
            if(_isOn)
            {
                _isOn = false;
                gameObject.SetActive(false);
            }
            else
            {
                _isOn = true;
                gameObject.SetActive(true);
            }
        }
    }
}