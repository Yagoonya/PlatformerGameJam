using Characters.Player;
using UnityEngine;

public class HideHero : MonoBehaviour
{
    [SerializeField] private bool _lightSave;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            if (player != null)
            {
                if (_lightSave)
                {
                    player.Hide();
                }
                else
                {
                    player.InW2Bush();
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            if (player != null)
            {
                if (_lightSave)
                {
                    player.Hide();
                }
                else
                {
                    player.InW2Bush();
                }
            }
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.ResetToDefault();
        }
    }
    
}
