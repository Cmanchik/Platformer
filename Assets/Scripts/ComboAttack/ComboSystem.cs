using SystemsManager;
using UnityEngine;

namespace ComboAttack
{
    public class ComboSystem : AbstractSystem
    {
        [SerializeField] private AttackAnimationControl animationControl;

        [SerializeField] private ComboLogic comboLogic;

        [SerializeField] private InputAttackController input;

        public override void Action()
        {
            string nameTriggerAnim = null;

            if (input.Attack1) nameTriggerAnim = comboLogic.CompleteCombo(input.Attack1AxisName);
            if (input.Attack2) nameTriggerAnim = comboLogic.CompleteCombo(input.Attack2AxisName);

            if (nameTriggerAnim != null) animationControl.Animate(nameTriggerAnim);
        }
        
        
    }
}