using UnityEngine;

namespace Movement
{
    public class PlayerInputMoveController : InputMoveController
    {
        public override float AxisHorizontal => Input.GetAxis("Horizontal");

        public override bool Jump => Input.GetButtonDown("Jump");
    }
}
