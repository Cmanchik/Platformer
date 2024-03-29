﻿using BuffDebuff;
using ComboAttack;
using UnityEngine;

namespace Attack
{
    public class DamageScript : MonoBehaviour
    {
        private Attack _attack;
        private ComboLogic _comboSystem;

        [SerializeField] private float baseDamage;

        private void Awake()
        {
            _comboSystem = GetComponentInParent<ComboLogic>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer != 10) return;

            PoisonEffect effect = collision.gameObject.AddComponent<PoisonEffect>();
            effect.Init(10, 2, 10);

            _attack = new Attack(baseDamage * _comboSystem.GetCurrentDamageMultiplier(), effect);
            collision.GetComponent<TakingDamage>().TakeDamage(_attack);
        }
    }
}