using System;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public KeyCode Attack1Code = KeyCode.Mouse0;
    public KeyCode Attack2Code = KeyCode.Mouse1;

    [NonSerialized] public bool isAttack1;

    [NonSerialized] public bool isAttack2;

    [NonSerialized] public bool isDown;

    [NonSerialized] public bool isJump;

    [NonSerialized] public bool isLeft;

    [NonSerialized] public bool isRight;


    [NonSerialized] public bool isUp;

    public KeyCode jumpCode = KeyCode.W;
    public KeyCode moveDownCode = KeyCode.S;
    public KeyCode moveLeftCode = KeyCode.A;
    public KeyCode moveRightCode = KeyCode.D;

    private void Update()
    {
        isAttack1 = Input.GetKeyDown(Attack1Code);
        isAttack2 = Input.GetKeyDown(Attack2Code);

        isUp = Input.GetKey(jumpCode);
        isLeft = Input.GetKey(moveLeftCode);
        isDown = Input.GetKey(moveDownCode);
        isRight = Input.GetKey(moveRightCode);

        isJump = Input.GetKeyDown(jumpCode);
    }
}