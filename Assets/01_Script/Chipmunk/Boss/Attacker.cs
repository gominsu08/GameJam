using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] ContactFilter2D _contactFilter = new() { };
    [SerializeField] Collider2D attackerCollider;
    [SerializeField] int _detectCount;
    Collider2D[] colliders = new Collider2D[10];
    private void Awake()
    {
        if (attackerCollider == null)
        {
            attackerCollider = GetComponent<Collider2D>();
        }

    }
    public virtual void Attack(int damage)
    {
        int count = Physics2D.OverlapCollider(attackerCollider, _contactFilter, colliders);
        for (int i = 0; i < count; i++)
            if (colliders[i].TryGetComponent<Health>(out Health health))
            {
                health.HP -= damage;
            }
    }
}
