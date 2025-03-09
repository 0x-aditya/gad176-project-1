using UnityEngine;

public class Rifle : Weapon
{
    [Header("Rifle Settings")]
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private float projectileLifeTime = 2f;
    
    private float nextFireTime = 0f;

    public override void Shoot()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            var rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            Destroy(bullet, projectileLifeTime);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
}