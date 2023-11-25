using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public ExplodingProjectile projectile;

    private float calculatedDamage;

    private void Awake()
    {
        projectile.gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (projectile != null && projectile.gameManager != null)
        {
            calculatedDamage = projectile.damageMultiplier * projectile.gameManager.damageValue * projectile.explosionDamageMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fish" || collision.tag == "Target")
        {
            projectile.fish = collision.GetComponent<Fish>();
            projectile.fish.TakeDamage(calculatedDamage);
            Debug.Log(calculatedDamage);
        }
    }
}