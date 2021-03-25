using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMoveController : InputMoveController
{
    public override float AxisHorizontal 
    { 
        get
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public override bool Jump 
    { 
        get
        {
            return Input.GetButtonDown("Jump");
        }
    }
}
