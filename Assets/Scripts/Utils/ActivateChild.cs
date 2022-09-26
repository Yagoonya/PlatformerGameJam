using UnityEngine;

namespace Utils
{
    public class ActivateChild : MonoBehaviour
    {
        private Transform obj;

        private void Awake()
        {
            obj = GetComponent<Transform>();
        }

        public void ActivateChildren(bool value)
        {
            for (int i = 0; i < obj.childCount; i++)
            {
                obj.GetChild(i).gameObject.SetActive(value);
            }
        }
    }
}