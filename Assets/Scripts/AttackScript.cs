using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class AttackScript : MonoBehaviour
{
    [SerializeField]
    private float damage;
    public float Damage { get { return damage; } }

    [Space(15)]

    [SerializeField]
    private bool manyAttackPerCollision;

    [SerializeField]
    private float сooldownAttack;
    public float CooldownAttack { get { return сooldownAttack; } }

    private bool canAttack;

    [Space(15)]

    [SerializeField]
    private bool isRigidBody;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = !isRigidBody;
        canAttack = true;

        if (!manyAttackPerCollision)
        {
            сooldownAttack = 0;
        }
    }

    /// <summary>
    /// Первое касание при isRigidbody = false
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canAttack)
        {
            Attack(collision.GetComponent<HealthScript>());
        }
    }

    /// <summary>
    /// Первое касание при isRigidbody = true
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canAttack)
        {
            Attack(collision.collider.GetComponent<HealthScript>());
        }
    }

    /// <summary>
    /// Повторные касания при isRigidbody = false
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canAttack && manyAttackPerCollision)
        {
            Attack(collision.GetComponent<HealthScript>());
        }
    }

    /// <summary>
    /// Повторные касания при isRigidbody = true
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canAttack && manyAttackPerCollision)
        {
            Attack(collision.collider.GetComponent<HealthScript>());
        }
    }

    private IEnumerator StartCooldownAttack()
    {
        yield return new WaitForSeconds(сooldownAttack);

        canAttack = true;
    }

    private void Attack(HealthScript health)
    {
        if (health)
        {
            health.SetDamage(damage);
            canAttack = false;

            StartCoroutine(StartCooldownAttack());
        }
    }
}
