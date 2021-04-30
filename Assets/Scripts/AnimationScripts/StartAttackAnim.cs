using UnityEngine;

namespace AnimationScripts
{
    public class StartAttackAnim : StateMachineBehaviour
    {
        [SerializeField] private string triggerName;
        private static readonly int IsAttack = Animator.StringToHash("isAttack");

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetTrigger(triggerName);
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(IsAttack, true);
        }

    }
}
