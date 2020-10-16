using System;
using System.Collections;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    [SerializeField]
    protected float actionTime;

    [SerializeField]
    protected float tickTime;

    [SerializeField]
    protected float tickDamage;

    protected EffectState state;
    public EffectState State { get { return state; } }

    protected EffectType type;
    public EffectType Type { get { return type; } }

    public float FullDamage { get { return actionTime / tickTime * tickDamage; } }

    protected IEnumerator startingCoroutine;

    public virtual void Run()
    {
        if (state == EffectState.Start) End();

        state = EffectState.Start;
        startingCoroutine = Action();
        StartCoroutine(startingCoroutine);
    }

    public virtual void End()
    {
        state = EffectState.End;
        StopCoroutine(startingCoroutine);
    }

    protected abstract IEnumerator Action();
}
