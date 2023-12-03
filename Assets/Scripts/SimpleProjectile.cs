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
            float damageTaken = damageMultiplier * gameManager.damageValue;
            fish = collision.GetComponent<Fish>();
            fish.TakeDamage(damageTaken);

            gameManager.DisplayDamage(damageTaken, fish.transform.position);

            Destroy(gameObject);
        }
    }
}
