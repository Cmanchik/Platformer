using System;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    [SerializeField]
    private ComboAttack[] comboAttacks;

    private int _numCombo = 0;
    private float lastAttackTime;

    public string CheckCombo(KeyCode keyCode)
    {
        string nameTriggerAnimation = null;
        foreach (ComboAttack combo in comboAttacks)
        {
            // проверка на соответствие этапу комбо
            // проверка на соответсвии кнопок на текущем этапе комбо
            // проверка на поподание в тайминг удара
            KeyCode? code = combo.GetTriggerButton(_numCombo);
            if (_numCombo != combo.NumCombo || code == null ||
                !HitTimeRange(Time.time, lastAttackTime, combo.GetTimeAttack(_numCombo)))
            {
                if (combo.NumCombo != 1) combo.ResetCombo();
                return null;
            }
            //если все проверки пройденны, то это нужное комбо
            else
            {
                nameTriggerAnimation = combo.GetAnimationName(_numCombo);
                lastAttackTime = Time.time;
                combo.NumCombo++;
                _numCombo++;
            }
        }

        return nameTriggerAnimation;
    }

    private bool HitTimeRange(float currentTime, float lastTime, float? rangeTime)
    {
        return currentTime - lastTime < rangeTime;
    }
}
