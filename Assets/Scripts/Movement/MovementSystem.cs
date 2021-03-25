using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField]
    private MoveLogic moveLogic;

    [SerializeField]
    private MovementAnimationControl animationControl;

    [SerializeField]
    private InputMoveController inputController;

    private void Start()
    {
        if (!moveLogic)
        {
            Debug.LogError("Отсутствует компонент moveLogic");
            enabled = false;
        }

        if (!animationControl)
        {
            Debug.LogError("Отсутствует компонент MovementAnimationControl");
            enabled = false;
        }

        if (inputController == null)
        {
            Debug.LogError("Отсутствует компонент IInputMoveController");
            enabled = false;
        }
    }

    private void Update()
    {
        moveLogic.Move(inputController.AxisHorizontal);
        if (inputController.Jump) moveLogic.Jump();

        animationControl.Animate(moveLogic.State);
    }
}
