namespace Movement
{
    public class PlayerInputMoveController : InputMoveController
    {
        private PlayerInput _playerInput;

        public override float AxisHorizontal => _playerInput.Player.Move.ReadValue<float>();

        public override bool Jump => _playerInput.Player.Jump.triggered;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }
    }
}