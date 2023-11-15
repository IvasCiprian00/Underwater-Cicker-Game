using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileClass : MonoBehaviour
{
    public float baseBulletSpeed;

    public float baseBulletDamage;

    public void SetDamage(float damage)
    {
        baseBulletDamage = damage;
    }

    public float GetDamage()
    {
        return baseBulletDamage;
    }

    public void SetSpeed(float speed)
    {
        baseBulletSpeed = speed;
    }

    public void Movement()
    {
        transform.Translate(Vector3.down * baseBulletSpeed * Time.deltaTime);
    }

    public void CheckOffscreen()
    {
        if(transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}
