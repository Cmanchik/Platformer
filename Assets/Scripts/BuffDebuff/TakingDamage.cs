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
        buffDebuffSystem.SetDamage(attack);
        healthScript.SetDamage(attack.Damage);
    }
}
