using UnityEngine.InputSystem;

namespace Movement
{
    public class PlayerInputMoveController : InputMoveController
    {
        private PlayerInput _playerInput;

        public override float AxisHorizontal => _playerInput.actions["Move"].ReadValue<float>();

        public override bool Jump => _playerInput.actions["Jump"].triggered;

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
        }
    }
}