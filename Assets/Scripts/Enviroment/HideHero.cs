using Characters.Player;
using UnityEngine;

public class HideHero : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            if (player != null)
            {
                player.SwitchVisability();
            }
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.SwitchVisability();
        }
    }
    
}
