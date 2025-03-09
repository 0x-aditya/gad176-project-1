using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float bulletForce = 20f;
    [SerializeField] protected float damage = 10f;

    public abstract void Shoot();
}
