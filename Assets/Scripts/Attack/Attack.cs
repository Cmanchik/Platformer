using System.Collections;

public class Attack : IEnumerable
{
    public float Damage { get; }
    public Effect[] Effects { get; }

    public Attack(float damage, params Effect[] effects)
    {
        this.Damage = damage;
        this.Effects = effects;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    public AttackEnumerator GetEnumerator()
    {
        return new AttackEnumerator(Effects);
    }
}
