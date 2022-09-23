using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Characters.Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _player.SetDirection(direction);
        }
    }
}

