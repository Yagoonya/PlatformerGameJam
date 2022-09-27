using System;
using Characters.Player;
using UnityEngine;

public class CoverPlayer : MonoBehaviour
{
    private bool _isCovered;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            if (player != null)
            {
                _isCovered = true;
                player.Cover();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            if (_isCovered && player.IsVisible)
            {
                if (player != null)
                {
                    player.Cover();
                }
            }
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            _isCovered = false;
            player.Uncover();
        }
    }
}
