using System.Collections;
using UnityEngine;

namespace BuffDebuff
{
    public abstract class Effect : MonoBehaviour
    {
        [SerializeField]
        protected float actionTime;

        [SerializeField]
        protected float tickTime;

        [SerializeField]
        protected float tickDamage;

        protected EffectState state;
        public EffectState State => state;

        protected EffectType type;
        public EffectType Type => type;

        public float FullDamage => actionTime / tickTime * tickDamage;

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
}
