using System.Collections;
using System.Collections.Generic;
using ComboAttack;
using UnityEngine;

public class DamageScriprt : MonoBehaviour
{
    [SerializeField]
    private float baseDamage;
    private ComboLogic comboSystem;

    private Attack attack;

    private void Awake()
    {
        comboSystem = GetComponentInParent<ComboLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 10) return;

        PoisonEffect effect = collision.gameObject.AddComponent<PoisonEffect>();
        effect.Init(10, 2, 10);

        attack = new Attack(baseDamage * comboSystem.GetCurrentDamageMultiplier(), effect);
        collision.GetComponent<TakingDamage>().TakeDamage(attack);
    }
}
