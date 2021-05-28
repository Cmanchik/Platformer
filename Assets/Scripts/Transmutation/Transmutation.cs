using CharacteristicsPersons;
using Transmutation.ArmorSets;
using UnityEngine;

namespace Transmutation
{
    [RequireComponent(typeof(Characteristics))]
    public class Transmutation : MonoBehaviour
    {
        private SpriteRenderer _sprite; // имитация визуальной смены брони
        private Characteristics _characteristics;
        
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