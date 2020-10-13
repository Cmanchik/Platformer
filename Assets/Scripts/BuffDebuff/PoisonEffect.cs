using System.Collections;
using UnityEngine;

public class PoisonEffect : Effect
{
    private TakingDamage takingDamage;

    //public PoisonEffect(float actionTime, float tickTime, float tickDamage)
    //{
    //    base.actionTime = actionTime;
    //    base.tickTime = tickTime;
    //    base.tickDamage = tickDamage;

    //    state = EffectState.NoStart;
    //    type = EffectType.Debuff;
    //}

    public void Init(float actionTime, float tickTime, float tickDamage)
    {
        base.actionTime = actionTime;
        base.tickTime = tickTime;
        base.tickDamage = tickDamage;

        state = EffectState.NoStart;
        type = EffectType.Debuff;
    }

    protected override IEnumerator Action()
    {
        takingDamage = GetComponent<TakingDamage>();

        for (float actionTime = base.actionTime; actionTime >= 0; actionTime -= tickTime)
        {
            takingDamage.TakeDamage(new Attack(tickDamage));

            yield return new WaitForSeconds(tickTime);
        }

        state = EffectState.End;
    }
}
