using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private PauseMenu _pauseMenu;

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

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _pauseMenu.SwitchPause();
            }
        }

        public void OnLookDown(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _player.LookDown();
            }

            if (context.canceled)
            {
                _player.LookUp();
            }
        }
    }
}