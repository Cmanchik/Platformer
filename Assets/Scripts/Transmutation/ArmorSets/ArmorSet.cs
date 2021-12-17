using CharacteristicsPersons;
using UnityEngine;

namespace Transmutation.ArmorSets
{
    [CreateAssetMenu(fileName = "New ArmorSet", menuName = "ArmorSet/Armor")]
    public class ArmorSet : ScriptableObject
    {
        [SerializeField] private Color color;

        [Range(0f, 1f)] [SerializeField] private float percentageProtection;

        [Range(0f, 2f)] [SerializeField] private float staminaConsumptionRate;

        [SerializeField] private WeightArmor weight;
        public WeightArmor Weight => weight;
        private bool IsActivated { get; set; }
        public Color Color => color;

        public void Init(Characteristics characteristics)
        {
            if (IsActivated) return;
            IsActivated = true;

            characteristics.PercentageProtection = percentageProtection;
            characteristics.StaminaConsumptionRate = staminaConsumptionRate;
        }
    }
}