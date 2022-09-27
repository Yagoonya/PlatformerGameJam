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
                player.Dead();
            }
        }
    }
}