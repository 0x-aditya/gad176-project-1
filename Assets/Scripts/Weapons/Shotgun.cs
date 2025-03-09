using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shotgun : Weapon
{
    [Header("Shotgun Settings")]
    [SerializeField] private int pellets = 5;
    [SerializeField] private float projectileLifeTime = 2f;

    [SerializeField] private float spreadAngle = 10f;

    public override void Shoot()
    {
        for (var i = 0; i < pellets; i++)
        {
            var angle = Random.Range(-spreadAngle, spreadAngle);
            var rotation = Quaternion.Euler(0, angle, 0);
            var direction = rotation * firePoint.forward;

            var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            var rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(direction * bulletForce, ForceMode.Impulse);
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