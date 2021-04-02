using UnityEngine;

namespace ComboAttack
{
    public class AttackAnimationControl : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        public void Animate(string animationTriggerName)
        {
            animator.SetTrigger(animationTriggerName);
        }
    }
}
