using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameManager gameManager;
    public Fish fish;

    [Header("Weapon Attributes")]
    public float bulletSpeed;
    public float damageMultiplier;

    private void Awake()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }


    public void Movement()
    {
        transform.Translate(Vector3.down * bulletSpeed * Time.deltaTime);
    }

    public void CheckOffscreen()
    {
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }

    //  Basic class methods

    public void SetDamageMultiplier(float damage)
    {
        damageMultiplier = damage;
    }

    public float GetDamageMultiplier()
    {
        return damageMultiplier;
    }

    public void SetSpeed(float speed)
    {
        bulletSpeed = speed;
    }

}
