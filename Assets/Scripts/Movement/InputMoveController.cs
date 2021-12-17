using SystemsManager;

namespace Movement
{
    public abstract class InputMoveController : AbstractInput
    {
        public virtual float AxisHorizontal { get; protected set; }
        public virtual bool Jump { get; protected set; }
    }
}