using UnityEngine;
using Characters.Player;

public class LightComponent : MonoBehaviour
{
    [SerializeField] protected Collider2D _collider;
    [SerializeField] protected SpriteRenderer _sprite;

    public void KillPlayer(GameObject other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.Dead();
        }
    }
}