using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [NonSerialized]
    public bool isAttack1;
    [NonSerialized]
    public bool isAttack2;


    [NonSerialized]
    public bool isUp;
    [NonSerialized]
    public bool isLeft;
    [NonSerialized]
    public bool isDown;
    [NonSerialized]
    public bool isRight;

    [NonSerialized]
    public bool isJump;

    public KeyCode jumpCode = KeyCode.W;
    public KeyCode moveLeftCode = KeyCode.A;
    public KeyCode moveRightCode = KeyCode.D;

    public KeyCode Attack1Code = KeyCode.Mouse0;
    public KeyCode Attack2Code = KeyCode.Mouse1;

    private void Update()
    {
        isAttack1 = Input.GetKeyDown(Attack1Code);
        isAttack2 = Input.GetKeyDown(Attack2Code);

        isUp = Input.GetKey(KeyCode.W);
        isLeft = Input.GetKey(KeyCode.A);
        isDown = Input.GetKey(KeyCode.S);
        isRight = Input.GetKey(KeyCode.D);

        isJump = Input.GetKeyDown(jumpCode);
    }
}
