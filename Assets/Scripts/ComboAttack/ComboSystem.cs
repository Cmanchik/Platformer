using System;
using TMPro;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    [SerializeField]
    private ComboAttack[] comboAttacks;

    private int indexCombo = 0;

    private float damageMultiplier;
    private float lastAttackTime;

    private Animator animator;
    private AnimatorStateInfo stateInfo;

    private void Awake()
    {
        damageMultiplier = 1;
        animator = GetComponent<Animator>();

        foreach (ComboAttack combo in comboAttacks)
        {
            combo.LoadTimeAnimation();
            combo.ResetCombo();
        }
    }

    public string CompleteCombo(KeyCode inputBtn)
    {
        string nameTriggerAnimation = null;
        damageMultiplier = 1;

        foreach (ComboAttack combo in comboAttacks)
        {
            KeyCode? comboBtn = combo.GetTriggerButton(indexCombo);

            if (indexCombo == combo.NumCombo && inputBtn == comboBtn && 
                HitTimeRange(Time.time, lastAttackTime, combo.GetTimeAttack(indexCombo - 1)))
            {
                combo.NumCombo += 1;

                if (nameTriggerAnimation == null)
                {
                    nameTriggerAnimation = combo.GetAnimationName(indexCombo);
                    lastAttackTime = Time.time;
                    indexCombo++;
                }
            }
            else
            {
                combo.ResetCombo();
            }
        }

        if (nameTriggerAnimation == null)
        {
            indexCombo = 0;
            foreach (ComboAttack combo in comboAttacks)
            {
                KeyCode? comboBtn = combo.GetTriggerButton(indexCombo);
                if (inputBtn == comboBtn)
                {
                    combo.NumCombo++;

                    if (nameTriggerAnimation == null)
                    {
                        nameTriggerAnimation = combo.GetAnimationName(indexCombo);
                        lastAttackTime = Time.time;
                        indexCombo++;
                    }
                }
            }
        }

        return nameTriggerAnimation;
    }

    private bool HitTimeRange(float currentTime, float lastTime, float? rangeTime)
    {
        if (rangeTime == null) return false;

        return currentTime - lastTime <= rangeTime;
    }

    public float GetCurrentDamageMultiplier()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsTag("Attack"))
        {
            foreach (ComboAttack combo in comboAttacks)
            {
                for (int i = 0; i < combo.MaxCombo; i++)
                {
                    
                    if (stateInfo.IsName(combo.GetAnimationName(i)))
                    {
                        damageMultiplier = combo.GetDamageMultiplier(i);
                        break;
                    }
                }
            }
        }
        else
        {
            damageMultiplier = 1;
        }

        return damageMultiplier;
    }
}