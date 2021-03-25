using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputAttackController : InputAttackController
{
    public override bool Attack1
    {
        get
        {
            return Input.GetButtonDown(attack1AxisName);
        }
    }

    
    public override bool Attack2
    {
        get
        {
            return Input.GetButtonDown(attack2AxisName);
        }
    }
}
