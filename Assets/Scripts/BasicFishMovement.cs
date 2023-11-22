using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFishMovement : MonoBehaviour
{
    public Fish fish;

    private void Awake()
    {
        fish.SetSpeed(Random.Range(0.9f, 1.1f));
    }

    private void Update()
    {
        fish.Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boat")
        {
            Destroy(gameObject);
            fish.gameManager.DamageShip(fish.damage);
        }
    }
}
