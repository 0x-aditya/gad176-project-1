using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float damage = 10;
    public string targetTag;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            if (targetTag == "Player") other.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            if (targetTag == "Enemy") other.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
