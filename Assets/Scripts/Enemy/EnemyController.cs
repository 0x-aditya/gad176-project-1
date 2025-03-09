using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyStats _stats;

    private void Start()
    {
        _stats = GetComponent<EnemyStats>();
    }
    public void TakeDamage(float damage)
    {
        _stats.Health -= damage;
        if (_stats.Health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    
}
