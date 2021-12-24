using UnityEngine.InputSystem;

namespace ComboAttack
{
    public class PlayerInputAttackController : InputAttackController
    {
        private PlayerInput _playerInput;

        public override bool Attack1 => _playerInput.actions["Attack1"].triggered;

        public override bool Attack2 => _playerInput.actions["Attack2"].triggered;

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
        }
    }
}