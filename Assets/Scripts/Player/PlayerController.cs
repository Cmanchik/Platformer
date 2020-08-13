using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementScript _movementScript;
    private Animator _animator;

    private void Awake()
    {
        _movementScript = GetComponent<MovementScript>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovementLogic();
        AnimationMovementLogic();
    }

    private void MovementLogic()
    {
        if (_movementScript)
        {
            _movementScript.Move(Input.GetAxis("Horizontal"));

            if (InputManager.Instance.isJump)
                _movementScript.Jump();
        }
    }

    private void AnimationMovementLogic()
    {
        if (_animator)
        {
            MovementState state = _movementScript.State;

            _animator.SetBool("Move", state == MovementState.Move);
            _animator.SetBool("Jump", state == MovementState.Jump);
        }
    }
}
