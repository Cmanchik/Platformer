using UnityEngine;

namespace Movement
{
    public class MovementAnimationControl : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        private static readonly int Move = Animator.StringToHash("Move");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Fall = Animator.StringToHash("Fall");

        public void Animate(MovementState state)
        {
            animator.SetBool(Move, state == MovementState.Move);
            animator.SetBool(Jump, state == MovementState.Jump);
            animator.SetBool(Fall, state == MovementState.Fall);
        }
    }
}
