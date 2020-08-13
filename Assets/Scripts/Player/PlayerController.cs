using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private MovementScript movementScript;

    private void Awake()
    {
        movementScript = GetComponent<MovementScript>();
    }

    private void Update()
    {
        MovementLogic();  
    }

    private void MovementLogic()
    {
        if (movementScript)
        {
            movementScript.Move(Input.GetAxis("Horizontal"));

            if (InputManager.Instance.isJump)
                movementScript.Jump();
        }
    }
}
