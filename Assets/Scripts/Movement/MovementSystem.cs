using SystemsManager;
using UnityEngine;

namespace Movement
{
    public class MovementSystem : AbstractSystem
    {
        [SerializeField]
        private MoveLogic moveLogic;

        [SerializeField]
        private MovementAnimationControl animationControl;

        [SerializeField]
        private InputMoveController inputController;

        public override void Action()
        {
            moveLogic.Move(inputController.AxisHorizontal);
            if (inputController.Jump) moveLogic.Jump();
            
            animationControl.Animate(moveLogic.State);
        }
    }
}
