using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _player.SetDirection(direction);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _player.DoAttack();
            }
        }

        public void OnInvisible(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _player.HideInObject();
            }
        }

        public void OnSwitchWorld(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _player.SwitchWorld();
            }
        }
    }
}

