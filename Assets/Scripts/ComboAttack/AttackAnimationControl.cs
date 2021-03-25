using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationControl : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void Animate(string animationTriggerName)
    {
        animator.SetTrigger(animationTriggerName);
    }
}
