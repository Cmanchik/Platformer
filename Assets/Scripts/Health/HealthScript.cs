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
        private float _armorPoint;


        private bool _isVulnerability;

        [SerializeField] private UnityEvent deathEvent;

        [SerializeField] public float healthPoint;

        [SerializeField] private HitEvent hitEvent;

        [SerializeField] private float maxArmorPoint;

        [SerializeField] private float maxHealthPoint;

        [SerializeField] private float timeOffsetDeath;

        public HealthState State { get; private set; }

        public bool IsVulnerability
        {
            get => _isVulnerability;

            set
            {
                _isVulnerability = value;
                State = value ? HealthState.Vulnerability : HealthState.InVulnerability;
            }
        }

        private void Awake()
        {
            healthPoint = maxHealthPoint;
            _armorPoint = maxArmorPoint;

            _isVulnerability = true;
            State = HealthState.Vulnerability;
        }

        public void SetDamage(float damage)
        {
            if (!_isVulnerability) return;

            hitEvent.Invoke(damage);
            healthPoint -= damage - _armorPoint;

            if (healthPoint <= 0) Death(timeOffsetDeath);
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
            State = HealthState.Death;
        }

        private IEnumerator DeathTimer(float time)
        {
            yield return new WaitForSeconds(time);

            Destroy(gameObject);
        }
    }
}