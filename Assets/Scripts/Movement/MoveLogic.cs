using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MoveLogic : MonoBehaviour
{
    /// <summary>
    /// Скорость перемещение
    /// </summary>
    [SerializeField]
    [Tooltip("Скорость перемещение")]
    protected float speed;
    /// <summary>
    /// Скорость перемещение
    /// </summary>
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

    /// <summary>
    /// Сила прыжка
    /// </summary>
    [SerializeField]
    [Tooltip("Сила прыжка")]
    protected float jumpForce;
    /// <summary>
    /// Сила прыжка
    /// </summary>
    public float JumpForce
    {
        get { return jumpForce; }
        set
        {
            if (value < 0) jumpForce = 0;
            else jumpForce = value;
        }
    }

    /// <summary>
    /// Состояние перемещения
    /// </summary>
    protected MovementState _state;
    /// <summary>
    /// Состояние перемещения
    /// </summary>
    public MovementState State { get { return _state; } }
    

    [SerializeField]
    protected int _jumpCount;
    public int JumpCount { get { return _jumpCount; } }

    protected int _jumpCurrent;


    protected Rigidbody2D _rb;
    private bool _isGrounded;

    [Space]

    [SerializeField]
    protected Transform jumpPoint;
    [SerializeField]
    protected LayerMask[] groundLayer;

    [Space]

    [SerializeField]
    protected float widthCheckGround;
    [SerializeField]
    protected float heightCheckGround;

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

    /// <summary>
    /// Перемещение
    /// </summary>
    /// <param name="axisHorizontal">Направление по оси X</param>
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

    /// <summary>
    /// Прыжок
    /// </summary>
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

    /// <summary>
    /// Отслеживание сопрокосновения с землей
    /// </summary>
    private void IsGroundedUpdate()
    {
        _isGrounded = Physics2D.OverlapBox(jumpPoint.position, new Vector3(widthCheckGround, heightCheckGround), 0);

        if (_isGrounded)
        {
            _jumpCurrent = _jumpCount;
            _state = MovementState.Idle;
            return;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(jumpPoint.position, new Vector3(widthCheckGround, heightCheckGround));
    }
}
