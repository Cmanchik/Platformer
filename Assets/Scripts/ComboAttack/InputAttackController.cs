using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAttackController : MonoBehaviour
{
    [SerializeField]
    protected string attack1AxisName = "Fire1";
    public string Attack1AxisName { get { return attack1AxisName; } }
    public virtual bool Attack1 { get; private set; }

    [SerializeField]
    protected string attack2AxisName = "Fire1";
    public string Attack2AxisName { get { return attack2AxisName; } }
    public virtual bool Attack2 { get; private set; }
}
