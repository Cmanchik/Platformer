using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationControl : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void Animate(MovementState state)
    {
        animator.SetBool("Move", state == MovementState.Move);
        animator.SetBool("Jump", state == MovementState.Jump);
        animator.SetBool("Fall", state == MovementState.Fall);
    }
}
