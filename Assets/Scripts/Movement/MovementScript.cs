using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            if (value < 0) speed = 0;
            else speed = value;
        }
    }


    [SerializeField]
    private float jumpForce;
    public float JumpForce
    {
        get { return jumpForce; }
        set
        {
            if (value < 0) jumpForce = 0;
            else jumpForce = value;
        }
    }


    private MovementState _state;
    public MovementState State { get { return _state; } }
    

    [SerializeField]
    private int _jumpCount;
    public int JumpCount { get { return _jumpCount; } }

    private int _jumpCurrent;


    private Rigidbody2D _rb;
    private bool _isGrounded;

    [Space]

    public Transform jumpPoint;
    public LayerMask[] groundLayer;

    [Space]

    public float widthCheckGround;
    public float heightCheckGround;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _isGrounded = false;
        _state = MovementState.Idle;
        _jumpCurrent = _jumpCount;
    }


    private void LateUpdate()
    {
        if (_rb.velocity.y < -0.1f && !_isGrounded) _state = MovementState.Fall;
    }

    public void Move(float axisHorizontal)
    {
        _rb.velocity = new Vector2(axisHorizontal * speed, _rb.velocity.y);

        if (axisHorizontal > 0) transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        else if (axisHorizontal < 0) transform.rotation = Quaternion.Euler(new Vector2(0, 180));

        if (_state != MovementState.Jump && _state != MovementState.Fall)
        {
            if (axisHorizontal != 0) _state = MovementState.Move;
            else _state = MovementState.Idle;
        }
    }

    public void Jump()
    {
        if (_jumpCurrent > 0 || _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _state = MovementState.Jump;
            _isGrounded = false;
            _jumpCurrent--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        IsGroundedUpdate();
    }

    private void IsGroundedUpdate()
    {
        foreach (LayerMask layer in groundLayer)
        {
            _isGrounded = Physics2D.OverlapBox(jumpPoint.position, new Vector3(widthCheckGround, heightCheckGround), 0);

            if (_isGrounded)
            {
                _jumpCurrent = _jumpCount;
                _state = MovementState.Idle;
                return;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(jumpPoint.position, new Vector3(widthCheckGround, heightCheckGround));
    }

    public void ClimbUp()
    {
        if (GetComponent<ClimbUpScript>() == null)
        {
            ClimbUpScript script = gameObject.AddComponent<ClimbUpScript>();
            script.speed = speed;
            script.StartClimb();
        }
    }
}
