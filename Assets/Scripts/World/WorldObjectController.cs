using UnityEngine;

public class WorldObjectController : MonoBehaviour
{
    private Animator animator;
    public bool InteractObject { get; set; }
    public string AnimInteractObject { get; private set; }

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