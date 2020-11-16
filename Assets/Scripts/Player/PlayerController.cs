using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementScript _movementScript;
    private Animator _animator;
    private ComboSystem _comboSystem;
    private WorldObjectController _worldObjectController;

    private void Awake()
    {
        _movementScript = GetComponent<MovementScript>();
        _comboSystem = GetComponent<ComboSystem>();
        _animator = GetComponent<Animator>();
        _worldObjectController = GetComponent<WorldObjectController>();
    }

    private void Update()
    {
        if (!_worldObjectController.InteractObject)
        {
            MovementLogic();
            AnimationMovementLogic();
            AnimationComboSystemLogic(ComboSystemLogic());
        }
        else
        {
            AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);
            _worldObjectController.InteractObject = info.IsTag("AnimInteractObject");
        }
        
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
            _animator.SetBool("Fall", state == MovementState.Fall);
        }
    }

    private string ComboSystemLogic()
    {
        string animName = null;
        if (_comboSystem)
        {
            if (InputManager.Instance.isAttack1) animName = _comboSystem.CompleteCombo(InputManager.Instance.Attack1Code);
            else if (InputManager.Instance.isAttack2) animName = _comboSystem.CompleteCombo(InputManager.Instance.Attack2Code);
        }
        
        return animName;
    }

    private void AnimationComboSystemLogic(string animationTriggerName)
    {
        if (_animator && animationTriggerName != null)
        {
            _animator.SetTrigger(animationTriggerName);
        }
    }
}
