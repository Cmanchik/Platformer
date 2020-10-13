using System;
using TMPro;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    [SerializeField]
    private ComboAttack[] comboAttacks;

    private int _numCombo = 0;
    public int NumCombo { get { return _numCombo; } }

    private float maxDamageMultiplier;
    private float lastAttackTime;

    private void Awake()
    {
        maxDamageMultiplier = 1;

        foreach (ComboAttack combo in comboAttacks)
        {
            combo.LoadTimeAnimation();
            combo.ResetCombo();
        }
    }

    public string CompleteCombo(KeyCode inputBtn)
    {
        string nameTriggerAnimation = null;
        maxDamageMultiplier = 1;

        foreach (ComboAttack combo in comboAttacks)
        {
            KeyCode? comboBtn = combo.GetTriggerButton(_numCombo);

            if (_numCombo == combo.NumCombo && inputBtn == comboBtn && 
                HitTimeRange(Time.time, lastAttackTime, combo.GetTimeAttack(_numCombo - 1)))
            {
                combo.NumCombo += 1;

                if (nameTriggerAnimation == null)
                {
                    if (maxDamageMultiplier < combo.ComboDamageMultiplier(_numCombo)) maxDamageMultiplier = combo.ComboDamageMultiplier(_numCombo);
                    nameTriggerAnimation = combo.GetAnimationName(_numCombo);
                    lastAttackTime = Time.time;
                    _numCombo++;
                }
            }
            else
            {
                //Debug.Log(String.Format("_numCombo: {0} | NumCombo: {1}", _numCombo, combo.NumCombo));
                //Debug.Log(String.Format("_numCombo == combo.NumCombo: {0} | inputBtn == comboBtn: {1} | HitTimeRange: {2} | name: {3}", _numCombo == combo.NumCombo, inputBtn == comboBtn, HitTimeRange(Time.time, lastAttackTime, combo.GetTimeAttack(_numCombo)), combo.GetAnimationName(_numCombo)));
                combo.ResetCombo();
            }
        }

        if (nameTriggerAnimation == null)
        {
            _numCombo = 0;
            foreach (ComboAttack combo in comboAttacks)
            {
                KeyCode? comboBtn = combo.GetTriggerButton(_numCombo);
                if (inputBtn == comboBtn)
                {
                    combo.NumCombo++;

                    if (nameTriggerAnimation == null)
                    {
                        nameTriggerAnimation = combo.GetAnimationName(_numCombo);
                        lastAttackTime = Time.time;
                        _numCombo++;
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
        return maxDamageMultiplier;
    }
}