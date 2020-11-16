using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectController : MonoBehaviour
{
    public bool InteractObject { get; set; } = false;
    public string AnimInteractObject { get; private set; }

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void InteractWithObject(string startTrigger)
    {
        AnimInteractObject = startTrigger;
        InteractObject = true;

        animator.SetTrigger(startTrigger);
    }

    
}
