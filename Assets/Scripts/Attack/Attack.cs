using System.Collections;

public class Attack : IEnumerable
{
    private float damage;
    public float Damage { get { return damage; } }

    private Effect[] effects;
    public Effect[] Effects { get { return effects; } }

    public Attack(float damage, params Effect[] effects)
    {
        this.damage = damage;
        this.effects = effects;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    public AttackEnumerator GetEnumerator()
    {
        return new AttackEnumerator(effects);
    }
}
