﻿using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class MoveLogic : MonoBehaviour
    {
        private float _axisHorizontal;
        private bool _isGrounded;

        [SerializeField] protected LayerMask[] groundLayer;

        [SerializeField] protected float heightCheckGround;


        [SerializeField] protected int jumpCount;

        protected int JumpCurrent;

        /// <summary>
        ///     Сила прыжка
        /// </summary>
        [SerializeField] [Tooltip("Сила прыжка")]
        protected float jumpForce;

        [Space] [SerializeField] protected Transform jumpPoint;


        protected Rigidbody2D Rb;

        /// <summary>
        ///     Скорость перемещение
        /// </summary>
        [SerializeField] [Tooltip("Скорость перемещение")]
        protected float speed;

        /// <summary>
        ///     Состояние перемещения
        /// </summary>
        protected MovementState state;

        [Space] [SerializeField] protected float widthCheckGround;

        /// <summary>
        ///     Скорость перемещение
        /// </summary>
        public float Speed
        {
            get => speed;

            set
            {
                if (value < 0) speed = 0;
                else speed = value;
            }
        }

        /// <summary>
        ///     Сила прыжка
        /// </summary>
        public float JumpForce
        {
            get => jumpForce;
            set
            {
                if (value < 0) jumpForce = 0;
                else jumpForce = value;
            }
        }

        public float AxisHorizontal
        {
            set => _axisHorizontal = value;
        }

        /// <summary>
        ///     Состояние перемещения
        /// </summary>
        public MovementState State => state;

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            _isGrounded = false;
            state = MovementState.Idle;
            JumpCurrent = jumpCount;
        }


        private void LateUpdate()
        {
            if (Rb.velocity.y < -0.1f && !_isGrounded) state = MovementState.Fall;

            if (state == MovementState.Jump || state == MovementState.Fall) return;
            state = _axisHorizontal != 0 ? MovementState.Move : MovementState.Idle;
        }

        /// <summary>
        ///     Перемещение
        /// </summary>
        /// <param name="axisHorizontal">Направление по оси X</param>
        public void Move(float axisHorizontal)
        {
            Rb.velocity = new Vector2(axisHorizontal * speed, Rb.velocity.y);

            if (axisHorizontal > 0) transform.rotation = Quaternion.Euler(new Vector2(0, 0));
            else if (axisHorizontal < 0) transform.rotation = Quaternion.Euler(new Vector2(0, 180));

            _axisHorizontal = axisHorizontal;
        }

        /// <summary>
        ///     Прыжок
        /// </summary>
        public void Jump()
        {
            if (JumpCurrent <= 0 || !_isGrounded) return;

            Rb.velocity = new Vector2(Rb.velocity.x, jumpForce);
            state = MovementState.Jump;
            _isGrounded = false;
            JumpCurrent--;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            IsGroundedUpdate();
        }

        /// <summary>
        ///     Отслеживание соприкосновения с землей
        /// </summary>
        private void IsGroundedUpdate()
        {
            _isGrounded = Physics2D.OverlapBox(
                jumpPoint.position, new Vector3(widthCheckGround, heightCheckGround), 0);

            if (!_isGrounded) return;

            JumpCurrent = jumpCount;
            state = MovementState.Idle;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(jumpPoint.position, new Vector3(widthCheckGround, heightCheckGround));
        }
    }
}