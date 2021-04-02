using UnityEngine;
using UnityEngine.Events;

namespace SystemsManager
{
    public abstract class AbstractInput : MonoBehaviour
    {
        public virtual bool IsInput { get; }
    }
}
