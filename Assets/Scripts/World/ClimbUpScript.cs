using UnityEngine;

public class ClimbUpScript : MonoBehaviour
{
    private Vector2 firstDir;
    private Vector2 firstPos;
    private bool isFirstPos;

    private bool isStart;

    private Rigidbody2D rb;
    private Vector2 secondDir;
    private Vector2 secondPos;

    public float speed;

    public void StartClimb()
    {
        isStart = true;
        firstPos = new Vector2(transform.position.x, transform.position.y + 5f);

        if (transform.rotation.y == 0) secondPos = new Vector2(firstPos.x + 2, firstPos.y);
        else secondPos = new Vector2(firstPos.x - 2, firstPos.y);


        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void FixedUpdate()
    {
        if (isStart)
        {
            if (!isFirstPos)
            {
                rb.velocity = new Vector2(0, 1) * speed;
                if (Vector2.Distance(transform.position, firstPos) <= 1) isFirstPos = true;
            }
            else
            {
                //transform.position = Vector2.Lerp(transform.position, secondPos, 0.01f);
                rb.velocity = new Vector2(-1, 0) * speed;
                if (Vector2.Distance(transform.position, secondPos) <= 1)
                {
                    isStart = false;
                    isFirstPos = false;
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    Destroy(this);
                }
            }
        }
    }
}