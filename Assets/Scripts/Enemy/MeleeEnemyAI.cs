using System;
using UnityEngine;

public class MeleeEnemyAI : GenericEntityAI
{
    protected override void Attack()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, Stats.attackRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                hit.collider.GetComponent<PlayerStats>().TakeDamage(Stats.Damage);
            }
        }
    }

    private void Update()
    {
        Move();
    }
}
