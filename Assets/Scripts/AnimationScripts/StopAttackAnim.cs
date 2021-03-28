using UnityEngine;

namespace AnimationScripts
{
    public class StopAttackAnim : StateMachineBehaviour
    {
        private static readonly int IsAttack = Animator.StringToHash("isAttack");
        private static readonly int Attack1 = Animator.StringToHash("Attack1");
        private static readonly int Attack2 = Animator.StringToHash("Attack2");
        private static readonly int Attack3 = Animator.StringToHash("Attack3");

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(IsAttack, false);

            animator.ResetTrigger(Attack1);
            animator.ResetTrigger(Attack2);
            animator.ResetTrigger(Attack3);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}
