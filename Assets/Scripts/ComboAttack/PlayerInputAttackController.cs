using UnityEngine;

public class PlayerInputAttackController : InputAttackController
{
    public override bool Attack1 => Input.GetButtonDown(attack1AxisName);
    
    public override bool Attack2 => Input.GetButtonDown(attack2AxisName);
}
