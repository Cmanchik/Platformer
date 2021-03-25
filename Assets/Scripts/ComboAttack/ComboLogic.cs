using System;
using TMPro;
using UnityEngine;

public class ComboLogic : MonoBehaviour
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

    /// <summary>
    /// Выполнение комбо атаки
    /// </summary>
    /// <param name="axis"></param>
    /// <returns>Название анимации текущей атаки</returns>
    public string CompleteCombo(string axis)
    {
        string nameTriggerAnimation = null;
        damageMultiplier = 1;

        // поиск комбонаций для продолжения
        foreach (ComboAttack combo in comboAttacks)
        {
            string comboBtn = combo.GetTriggerButton(indexCombo);

            if (indexCombo == combo.NumCombo && axis == comboBtn && 
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

        // поиск новых комбинации для запуска с начала
        if (nameTriggerAnimation == null)
        {
            indexCombo = 0;
            foreach (ComboAttack combo in comboAttacks)
            {
                string comboBtn = combo.GetTriggerButton(indexCombo);
                if (axis == comboBtn)
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