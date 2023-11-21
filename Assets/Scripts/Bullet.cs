using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    private void Awake()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        SetDamageMultiplier(1f);
        SetFireRateMultiplier(0.5f);
        SetSpeed(20f);
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
