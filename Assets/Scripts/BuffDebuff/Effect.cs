using System.Collections;
using UnityEngine;

namespace BuffDebuff
{
    public abstract class Effect : MonoBehaviour
    {
        [SerializeField] protected float actionTime;

        protected IEnumerator startingCoroutine;

        protected EffectState state;

        [SerializeField] protected float tickDamage;

        [SerializeField] protected float tickTime;

        protected EffectType type;
        public EffectState State => state;
        public EffectType Type => type;

        public float FullDamage => actionTime / tickTime * tickDamage;

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
}