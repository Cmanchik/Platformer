using UnityEngine;

public class InputAttackController : MonoBehaviour
{
    [SerializeField]
    protected string attack1AxisName = "Fire1";
    public string Attack1AxisName => attack1AxisName;
    public virtual bool Attack1 { get; protected set; }

    [SerializeField]
    protected string attack2AxisName = "Fire1";
    public string Attack2AxisName => attack2AxisName;
    public virtual bool Attack2 { get; protected set; }
}
