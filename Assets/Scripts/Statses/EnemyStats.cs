using UnityEngine;

public class EnemyStats : Stats
{
    [Header("Movement")]
    public float speed;
    public float movementRangeFromPlayer;
    
    [Header("Attack")]
    public float attackRange;
    public float attackCooldown;
}
