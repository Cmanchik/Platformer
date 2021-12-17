using UnityEngine;

public class JointWithPlatform : MonoBehaviour
{
    [SerializeField] private string animationDown;

    [SerializeField] private string animationPlatformInteract;

    [SerializeField] private string animationUp;

    private WorldObjectController controller;
    private FixedJoint2D fixedJoint2D;

    private bool isInteracted;

    private void Start()
    {
        fixedJoint2D = GetComponent<FixedJoint2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("JointCollider") && !isInteracted)
        {
            fixedJoint2D.connectedBody = collision.GetComponentInParent<Rigidbody2D>();
            controller = collision.GetComponentInParent<WorldObjectController>();
            controller.InteractWithObject(animationPlatformInteract);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInteracted = false;
    }

    private void LateUpdate()
    {
        if (fixedJoint2D.connectedBody != null)
        {
            if ((InputManager.Instance.isJump || InputManager.Instance.isUp) && !isInteracted)
            {
                controller.InteractWithObject(animationUp);
                fixedJoint2D.connectedBody = null;
                controller = null;
                isInteracted = true;
            }
            else if (InputManager.Instance.isDown && !isInteracted)
            {
                controller.InteractWithObject(animationDown);
                fixedJoint2D.connectedBody = null;
                controller = null;
                isInteracted = true;
            }
        }
    }

    public void FinishInteract()
    {
        isInteracted = false;
    }
}