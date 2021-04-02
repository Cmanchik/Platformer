using UnityEngine;

namespace Movement
{
    public class PlayerInputMoveController : InputMoveController
    {
        public override float AxisHorizontal
        {
            get
            {
                //InputEvent.Invoke(this);
                return Input.GetAxis("Horizontal");
            }
        }

        public override bool Jump
        {
            get
            {
                //InputEvent.Invoke(this);
                return Input.GetButtonDown("Jump");
            } 
        }
    }
}
