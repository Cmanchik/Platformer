﻿using UnityEngine;

namespace ComboAttack
{
    public class PlayerInputAttackController : InputAttackController
    {
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        public override bool Attack1 => _playerInput.Player.Attack1.triggered;

        public override bool Attack2 => _playerInput.Player.Attack2.triggered;
    }
}
