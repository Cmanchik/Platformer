using UnityEngine;

namespace ComboAttack
{
    public class TestAttack : InputAttackController
    {
        public bool attack;
        public override bool Attack1 => attack;
    }
}
