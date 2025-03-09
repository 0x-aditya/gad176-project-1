using System;
using System.Collections;
using UnityEngine;

public abstract class GenericEntityAI : MonoBehaviour
{
    protected EnemyStats stats;
    public float speed;
    public float movementRangeFromPlayer;
    public float attackRange;
    public float attackCooldown;
    
    public GameObject target;
    protected float lastAttackTime;

    protected virtual void Start()
    {
        lastAttackTime = Time.time;
        stats = GetComponent<EnemyStats>();
    }

    protected abstract void Attack();
    
    public void Move()
    {
        var distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > movementRangeFromPlayer)
        {
            var direction = (target.transform.position - transform.position).normalized;
            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            transform.position += direction * speed * Time.deltaTime;
        }

        if (!(distance <= attackRange) || !(Time.time - lastAttackTime >= attackCooldown)) return;
        lastAttackTime = Time.time;
        Attack();
    }
}
