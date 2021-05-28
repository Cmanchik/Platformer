using CharacteristicsPersons;
using Transmutation.ArmorSets;
using UnityEngine;

namespace Transmutation
{
    [RequireComponent(typeof(Characteristics))]
    public class Transmutation : MonoBehaviour
    {
        
        private Characteristics _characteristics;
        private void Start()
        {
            _characteristics = GetComponent<Characteristics>();
        }

        public void ChangeArmor(ArmorSet armor)
        {
            armor.Init(_characteristics);
        }
    }
}