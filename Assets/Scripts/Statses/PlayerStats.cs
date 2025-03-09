using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : Stats
{
    
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");

    }
}
