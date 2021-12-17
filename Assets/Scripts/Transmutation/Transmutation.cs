using CharacteristicsPersons;
using Transmutation.ArmorSets;
using UnityEngine;

namespace Transmutation
{
    [RequireComponent(typeof(Characteristics))]
    public class Transmutation : MonoBehaviour
    {
        private Characteristics _characteristics;
        private SpriteRenderer _sprite; // имитация визуальной смены брони

        private void Start()
        {
            _characteristics = GetComponent<Characteristics>();
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void ChangeArmor(ArmorSet armor)
        {
            armor.Init(_characteristics);
            _sprite.color = armor.Color;
        }
    }
}