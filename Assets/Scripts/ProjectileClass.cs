using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileClass : MonoBehaviour
{
    public float bulletSpeed;

    public float bulletDamage;

    public void SetDamage(float damage)
    {
        bulletDamage = damage;
    }

    public float GetDamage()
    {
        return bulletDamage;
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
