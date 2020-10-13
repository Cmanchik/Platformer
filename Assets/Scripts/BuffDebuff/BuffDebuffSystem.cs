using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuffDebuffSystem : MonoBehaviour
{
    [SerializeField]
    private float timeCheckTime;

    private List<Effect> buffs;
    private List<Effect> debuffs;

    private void Awake()
    {
        buffs = new List<Effect>();
        debuffs = new List<Effect>();
    }

    private void Start()
    {
        Invoke("CheckEffects", 1);
    }

    public void SetDamage(Attack attack)
    {
        foreach (Effect effect in attack)
        {
            Effect activeEffect;
            switch (effect.Type)
            {
                case EffectType.Buff:
                    activeEffect = buffs.FirstOrDefault(elem => elem.name == effect.name);
                    if (!activeEffect) buffs.Add(effect);
                    else
                    {
                        activeEffect.Run();
                        continue;
                    }
                    break;
                case EffectType.Debuff:
                    activeEffect = debuffs.FirstOrDefault(elem => elem.name == effect.name);
                    if (!activeEffect) debuffs.Add(effect);
                    else
                    {
                        activeEffect.Run();
                        continue;
                    }
                    break;
            }

            effect.Run();
        }
    }

    private void CheckEffects()
    {
        for (int i = buffs.Count - 1; i >= 0; i--)
        {
            if (buffs[i].State == EffectState.End)
            {
                buffs[i].End();
                buffs.RemoveAt(i);
            }
        }

        for (int i = debuffs.Count - 1; i >= 0; i--)
        {
            if (debuffs[i].State == EffectState.End)
            {
                debuffs[i].End();
                buffs.RemoveAt(i);
            }
        }
    }
}
