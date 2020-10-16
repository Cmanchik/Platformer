using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScriprt : MonoBehaviour
{
    [SerializeField]
    private float baseDamage;
    private ComboSystem comboSystem;

    private Attack attack;

    private void Awake()
    {
        comboSystem = GetComponentInParent<ComboSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 10) return;

        attack = new Attack(baseDamage * comboSystem.GetCurrentDamageMultiplier());
        collision.GetComponent<TakingDamage>().TakeDamage(attack);
    }
}
