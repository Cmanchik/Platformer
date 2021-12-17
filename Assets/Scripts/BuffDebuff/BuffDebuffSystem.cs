using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BuffDebuff
{
    public class BuffDebuffSystem : MonoBehaviour
    {
        private List<Effect> _buffs;
        private List<Effect> _debuffs;

        [SerializeField] private float timeCheckTime;

        private void Awake()
        {
            _buffs = new List<Effect>();
            _debuffs = new List<Effect>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(CheckEffects), 0f, timeCheckTime);
        }

        public void SetDamage(Attack.Attack attack)
        {
            foreach (Effect effect in attack)
            {
                Effect activeEffect;
                switch (effect.Type)
                {
                    case EffectType.Buff:
                        activeEffect = _buffs.FirstOrDefault(elem => elem.name == effect.name);

                        if (!activeEffect)
                        {
                            _buffs.Add(effect);
                        }
                        else
                        {
                            if (activeEffect != null) activeEffect.Run();
                            Destroy(effect);
                            continue;
                        }

                        break;
                    case EffectType.Debuff:
                        activeEffect = _debuffs.FirstOrDefault(elem => elem.name == effect.name);

                        if (!activeEffect)
                        {
                            _debuffs.Add(effect);
                        }
                        else
                        {
                            if (activeEffect != null) activeEffect.Run();
                            Destroy(effect);
                            continue;
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                effect.Run();
            }
        }

        private void CheckEffects()
        {
            for (int i = _buffs.Count - 1; i >= 0; i--)
            {
                if (_buffs[i].State != EffectState.End) continue;

                _buffs[i].End();
                Destroy(_buffs[i]);
                _buffs.RemoveAt(i);
            }

            for (int i = _debuffs.Count - 1; i >= 0; i--)
            {
                if (_debuffs[i].State != EffectState.End) continue;

                _debuffs[i].End();
                Destroy(_debuffs[i]);
                _debuffs.RemoveAt(i);
            }
        }
    }
}