using UnityEngine;

public abstract class GenericEntityAI : MonoBehaviour
{
    protected EnemyStats Stats;
    protected GameObject target;

    protected float LastAttackTime;

    protected virtual void Start()
    {
        LastAttackTime = Time.time;
        Stats = GetComponent<EnemyStats>();
        target = GameObject.FindWithTag("Player");
    }

    protected abstract void Attack();

    protected void Move()
    {
        var distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > Stats.movementRangeFromPlayer)
        {
            var direction = (target.transform.position - transform.position).normalized;
            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Stats.speed * Time.deltaTime);
            transform.position += direction * (Stats.speed * Time.deltaTime);
        }

        if (!(distance <= Stats.attackRange) || !(Time.time - LastAttackTime >= Stats.attackCooldown)) return;
        LastAttackTime = Time.time;
        Attack();
    }
}
