﻿using BuffDebuff;
using Health;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    private BuffDebuffSystem buffDebuffSystem;
    private HealthScript healthScript;

    private void Awake()
    {
        buffDebuffSystem = GetComponent<BuffDebuffSystem>();
        healthScript = GetComponent<HealthScript>();
    }

    public void TakeDamage(Attack.Attack attack)
    {
        if (buffDebuffSystem) buffDebuffSystem.SetDamage(attack);
        if (healthScript) healthScript.SetDamage(attack.Damage);
    }
}