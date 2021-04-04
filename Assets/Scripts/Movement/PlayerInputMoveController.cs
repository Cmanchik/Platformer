namespace Movement
{
    public class PlayerInputMoveController : InputMoveController
    {
        private PlayerInput _playerInput;
        
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

        public override float AxisHorizontal => _playerInput.Player.Move.ReadValue<float>();

        public override bool Jump => _playerInput.Player.Jump.triggered; 
    }
}
