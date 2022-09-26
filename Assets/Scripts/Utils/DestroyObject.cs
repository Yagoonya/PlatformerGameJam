using UnityEngine;

namespace Utils
{
    public class DestroyObject : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToDestroy;
        
        public void DestroyIt()
        {
            Destroy(_objectToDestroy);
        }
    }
}