using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile: Projectile
{
    
    private void Update()
    {
        Movement();
        CheckOffscreen();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Target")
        {
            fish = collision.GetComponent<Fish>();
            fish.TakeDamage(damageMultiplier * gameManager.damageValue);

            Destroy(gameObject);
        }
    }
}
