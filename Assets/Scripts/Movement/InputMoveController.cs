using UnityEngine;

namespace Movement
{
    public abstract class InputMoveController : MonoBehaviour
    {
        public virtual float AxisHorizontal { get; protected set; }
        public virtual bool Jump { get; protected set; }
    }
}
