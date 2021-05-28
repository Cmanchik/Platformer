using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Health
{
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
        private float _armorPoint;

        [SerializeField]
        private float timeOffsetDeath;

        private HealthState _state;
        public HealthState State => _state;


        private bool _isVulnerability;
        public bool IsVulnerability 
        { 
            get => _isVulnerability;

            set
            {
                _isVulnerability = value;
                _state = value ? HealthState.Vulnerability : HealthState.InVulnerability;
            }
        }

        [SerializeField]
        private HitEvent hitEvent;

        [SerializeField]
        private UnityEvent deathEvent;

        private void Awake()
        {
            healthPoint = maxHealthPoint;
            _armorPoint = maxArmorPoint;

            _isVulnerability = true;
            _state = HealthState.Vulnerability;
        }

        public void SetDamage(float damage)
        {
            if (!_isVulnerability) return;
        
            hitEvent.Invoke(damage);
            healthPoint -= (damage - _armorPoint);

            if (healthPoint <= 0)
            {
                Death(timeOffsetDeath);
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
}