using System;
using System.Collections;
using BuffDebuff;

public class AttackEnumerator : IEnumerator
{
    public Effect[] effects;
    private int position = -1;

    public AttackEnumerator(Effect[] effects)
    {
        this.effects = effects;
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

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        position++;
        return position < effects.Length;
    }

    public void Reset()
    {
        position = -1;
    }
}