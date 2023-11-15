using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileClass : MonoBehaviour
{
    public GameManager gameManager;

    [Header("Weapon Attributes")]
    public float bulletSpeed;
    public float damageMultiplier;
    public float fireRateMultiplier;

    public void SetDamageMultiplier(float damage)
    {
        damageMultiplier = damage;
    }

    public float GetDamageMultiplier()
    {
        return damageMultiplier;
    }

    public void SetFireRateMultiplier(float fireRate)
    {
        fireRateMultiplier = fireRate;
    }

    public void SetSpeed(float speed)
    {
        bulletSpeed = speed;
    }

    public void Movement()
    {
        transform.Translate(Vector3.down * bulletSpeed * Time.deltaTime);
    }

    public void CheckOffscreen()
    {
        if(transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}
