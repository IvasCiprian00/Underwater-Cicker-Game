using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectile: Projectile
{
    [Header("Explosion Settings")]
    public GameObject explosion;
    public float explosionDamageMultiplier;
    public float explosionRadius;

    private void Start()
    {
        explosion.transform.localScale = new Vector3(explosionRadius, explosionRadius, 0);
    }

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

            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
