using Characters.Enemies.Boss;
using UnityEngine;
using Characters.Player;
using UnityEngine.Rendering.Universal;

public class LightComponent : MonoBehaviour
{
    [SerializeField] protected Collider2D _collider;
    [SerializeField] protected Light2D _sprite;

    public void KillPlayer(GameObject other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            ResetBossFight();
            player.Dead();
        }
    }

    private void ResetBossFight()
    {
        var boss = FindObjectOfType<BossBehaviour>();
        if (boss != null)
        {
            boss.ResetBossFight();
        }
    }
}