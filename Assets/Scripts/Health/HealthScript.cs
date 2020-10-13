using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum HealthState
{
    Vulnerability,
    InVulnerability,
    Death
}

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    private float maxHealthPoint;
    [SerializeField]
    private float healthPoint;

    [SerializeField]
    private float maxArmorPoint;
    private float armorPoint;

    [SerializeField]
    private float timeOffsetDeath;

    private HealthState _state;
    public HealthState State { get { return _state; } }


    private bool _isVulnerability;
    public bool IsVulnerability 
    { 
        get 
        { 
            return _isVulnerability; 
        }
        
        set
        {
            _isVulnerability = value;

            if (value) _state = HealthState.Vulnerability;
            else _state = HealthState.InVulnerability;
        }
    }

    [SerializeField]
    private HitEvent hitEvent;

    [SerializeField]
    private UnityEvent deathEvent;

    private void Awake()
    {
        healthPoint = maxHealthPoint;
        armorPoint = maxArmorPoint;

        _isVulnerability = true;
        _state = HealthState.Vulnerability;
    }

    public void SetDamage(float damage)
    {
        if (_isVulnerability)
        {
            hitEvent.Invoke(damage);
            healthPoint -= (damage - armorPoint);

            if (healthPoint <= 0)
            {
                Death(timeOffsetDeath);
            }
        } 
    }

    public void IncreaseMaxHealth(float healthPoint)
    {
        maxHealthPoint += healthPoint;
    }

    public void ReduceMaxHealth(float healthPoint)
    {
        maxHealthPoint -= healthPoint;

        if (healthPoint > maxHealthPoint) healthPoint = maxHealthPoint;
    }

    private void Death(float timeOffset)
    {
        deathEvent.Invoke();
        StartCoroutine(DeathTimer(timeOffset));
        _state = HealthState.Death;
    }

    private IEnumerator DeathTimer(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
