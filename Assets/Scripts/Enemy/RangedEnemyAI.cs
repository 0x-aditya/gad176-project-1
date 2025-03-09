using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class RangedEnemyAI : GenericEntityAI
{
    [Header("Run Away")]
    public float rangeOfMotion;
    
    [Header("Projectile")]
    public GameObject projectilePrefab;
    public float projectileSpeed;
    public float projectileLifetime;
    
    private bool isRunningAway = false;
    
    protected override void Attack()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        var projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectile.GetComponent<ProjectileDamage>().damage = Stats.Damage;
        projectileRigidbody.linearVelocity = (Stats.target.transform.position - transform.position).normalized * projectileSpeed;
        Destroy(projectile, projectileLifetime);
    }
    public void TookDamage()
    {
        StartCoroutine(RunAway());
    }

    private IEnumerator RunAway()
    {
        isRunningAway = true;
        var randomPosition = new Vector3(transform.position.x + Random.Range(-rangeOfMotion, rangeOfMotion),
            transform.position.y,
            transform.position.z + Random.Range(-rangeOfMotion, rangeOfMotion));
        while (Vector3.Distance(transform.position, randomPosition) > 1)
        {
            
            var direction = (randomPosition - transform.position).normalized;
            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Stats.speed * Time.deltaTime);
            transform.position += direction * (Stats.speed * Time.deltaTime);
            yield return null;
        }
        isRunningAway = false;
    }

    private void Update()
    {
        if (isRunningAway) return;
        Move();
    }
}
