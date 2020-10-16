using System;
using System.Collections;
using UnityEngine;

public class PoisonEffect : Effect
{
    private TakingDamage takingDamage;

    public void Init(float actionTime, float tickTime, float tickDamage)
    {
        this.actionTime = actionTime;
        this.tickTime = tickTime;
        this.tickDamage = tickDamage;

        state = EffectState.NoStart;
        type = EffectType.Debuff;
    }

    public override void Run()
    {
        if (state == EffectState.Start) End();
        if (!takingDamage) takingDamage = GetComponent<TakingDamage>();
        

        state = EffectState.Start;
        startingCoroutine = Action();
        StartCoroutine(startingCoroutine);
    }

    protected override IEnumerator Action()
    {
        for (float actionTime = base.actionTime; actionTime >= 0; actionTime -= tickTime)
        {
            takingDamage.TakeDamage(new Attack(tickDamage));

            yield return new WaitForSeconds(tickTime);
        }

        state = EffectState.End;
    }
}
