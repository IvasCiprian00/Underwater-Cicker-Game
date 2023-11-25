using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile: Projectile
{
    private void Awake()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        Movement();
        CheckOffscreen();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Target")
        {
            Destroy(gameObject);

            fish = collision.GetComponent<Fish>();
            fish.TakeDamage(damageMultiplier * gameManager.damageValue);
        }
    }
}
