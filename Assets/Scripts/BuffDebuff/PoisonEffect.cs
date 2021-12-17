using System.Collections;
using UnityEngine;

namespace BuffDebuff
{
    public class PoisonEffect : Effect
    {
        private TakingDamage _takingDamage;

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
            if (!_takingDamage) _takingDamage = GetComponent<TakingDamage>();

            state = EffectState.Start;
            startingCoroutine = Action();
            StartCoroutine(startingCoroutine);
        }

        protected override IEnumerator Action()
        {
            for (float time = actionTime; time >= 0; time -= tickTime)
            {
                _takingDamage.TakeDamage(new Attack.Attack(tickDamage));

                yield return new WaitForSeconds(tickTime);
            }

            state = EffectState.End;
        }
    }
}