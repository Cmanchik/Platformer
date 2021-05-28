using System;
using System.Collections;
using System.Collections.Generic;
using BuffDebuff;
using UnityEngine;

public class AttackEnumerator : IEnumerator
{
    public Effect[] effects;
    int position = -1;

    public AttackEnumerator(Effect[] effects)
    {
        this.effects = effects;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Effect Current
    {
        get
        {
            try
            {
                return effects[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public bool MoveNext()
    {
        position++;
        return (position < effects.Length);
    }

    public void Reset()
    {
        position = -1;
    }
}
