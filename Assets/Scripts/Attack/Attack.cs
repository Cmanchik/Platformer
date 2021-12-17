using System.Collections;
using BuffDebuff;

namespace Attack
{
    public class Attack : IEnumerable
    {
        public Attack(float damage, params Effect[] effects)
        {
            Damage = damage;
            Effects = effects;
        }

        public float Damage { get; }
        public Effect[] Effects { get; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public AttackEnumerator GetEnumerator()
        {
            return new AttackEnumerator(Effects);
        }
    }
}