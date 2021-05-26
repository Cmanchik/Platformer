using System;
using UnityEngine;

namespace Characteristics
{
    public class Characteristics : MonoBehaviour
    {
        /// <summary>
        /// Максимальное здоровье
        /// </summary>
        [SerializeField]
        [Tooltip("Максимальное здоровье")]
        private float maxHp = 100;
        /// <summary>
        /// Максимальное здоровье
        /// </summary>
        public float MaxHp
        {
            get => maxHp;
            set => maxHp = value;
        }
        
        /// <summary>
        /// Текущее здоровье
        /// </summary>
        private float _hp = 100;
        /// <summary>
        /// Текущее здоровье
        /// </summary>
        public float Hp
        {
            get => _hp;
            set => _hp = _hp + value > maxHp ? maxHp : _hp + value;
        }
        
        /// <summary>
        /// Максимальное значение выносливости
        /// </summary>
        [SerializeField]
        [Tooltip("Максимальное значение выносливости")]
        private float maxStamina = 100;
        /// <summary>
        /// Максимальное значение выносливости
        /// </summary>
        public float MaxStamina
        {
            get => maxStamina;
            set => maxStamina = value;
        }
        
        /// <summary>
        /// Текущее значение выносливости
        /// </summary>
        private float _stamina = 100;
        /// <summary>
        /// Текущее значение выносливости
        /// </summary>
        public float Stamina
        {
            get => _stamina;
            set => _stamina = value < _stamina ? value * StaminaConsumptionRate : value;
        }
        
        /// <summary>
        /// Скорость восполнения выносливости
        /// </summary>
        [SerializeField]
        [Tooltip("Скорость восполнения выносливости")]
        private float staminaReplenishmentRate = 3;
        
        /// <summary>
        /// Коэффициент расхода выносливости
        /// </summary>
        public float StaminaConsumptionRate { get; set; } = 1;

        /// <summary>
        /// Процент защиты
        /// </summary>
        public float PercentageProtection { get; set; } = 25;

        [SerializeField]
        [Tooltip("Сила атаки")]
        private float attackPower = 25;
        /// <summary>
        /// Сила атаки
        /// </summary>
        public float AttackPower
        {
            get => attackPower;
            set => attackPower = value;
        }

        private void Start()
        {
            InvokeRepeating(nameof(ReplenishStaminaOverTime), 0, 1);
        }

        private void ReplenishStaminaOverTime()
        {
            if (_stamina >= maxStamina) return;
            Stamina += staminaReplenishmentRate;
        }
    }
}
