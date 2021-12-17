using SystemsManager;
using UnityEngine;

namespace ComboAttack
{
    public abstract class InputAttackController : AbstractInput
    {
        [SerializeField] protected string attack1AxisName = "Fire1";

        [SerializeField] protected string attack2AxisName = "Fire2";

        public string Attack1AxisName => attack1AxisName;
        public virtual bool Attack1 { get; protected set; }
        public string Attack2AxisName => attack2AxisName;
        public virtual bool Attack2 { get; protected set; }

        public override bool IsInput => Attack1 || Attack2;
    }
}