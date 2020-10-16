using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    private HealthScript healthScript;
    private BuffDebuffSystem buffDebuffSystem;

    private void Awake()
    {
        buffDebuffSystem = GetComponent<BuffDebuffSystem>();
        healthScript = GetComponent<HealthScript>();
    }

    public void TakeDamage(Attack attack)
    {
        if (buffDebuffSystem) buffDebuffSystem.SetDamage(attack);
        if (healthScript) healthScript.SetDamage(attack.Damage);
    }
}
