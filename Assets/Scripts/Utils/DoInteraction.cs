using UnityEngine;

namespace Utils
{
    public class DoInteraction : MonoBehaviour
    {
        public void DoInteract(GameObject go)
        {
            var interactable = go.GetComponent<InteractableComponent>();
            if(interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
