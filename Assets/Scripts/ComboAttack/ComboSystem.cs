using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    [SerializeField]
    private ComboLogic comboLogic;

    [SerializeField]
    private AttackAnimationControl animationControl;

    [SerializeField]
    private InputAttackController inputController;

    private void Start()
    {
        if (!comboLogic)
        {
            Debug.LogError("Отсутствует компонент comboLogic");
            enabled = false;
        }

        if (!animationControl)
        {
            Debug.LogError("Отсутствует компонент animationControl");
            enabled = false;
        }

        if (inputController) return;
        Debug.LogError("Отсутствует компонент InputAttackController");
        enabled = false;
    }

    private void Update()
    {
        string nameTriggerAnim = null;
        if (inputController.Attack1) nameTriggerAnim = comboLogic.CompleteCombo(inputController.Attack1AxisName);
        else if (inputController.Attack2) nameTriggerAnim = comboLogic.CompleteCombo(inputController.Attack2AxisName);

        if (nameTriggerAnim != null)
        {
            animationControl.Animate(nameTriggerAnim);
        }

    }
}
