using Characters.Enemies.Boss;
using Characters.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class ReloadLevel : MonoBehaviour
    {
        public void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

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
}