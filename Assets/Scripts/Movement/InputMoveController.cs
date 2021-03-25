using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputMoveController : MonoBehaviour
{
    public virtual float AxisHorizontal { get; private set; }
    public virtual bool Jump { get; private set; }
}
