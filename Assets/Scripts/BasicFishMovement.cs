using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BasicFishMovement : MonoBehaviour
{
    public Fish fish;

    enum State
    {
        moving,
        charging,
        attacking
    }

    private State state;

    private void Awake()
    {
        fish.SetSpeed(Random.Range(0.9f, 1.1f));
        
        state = State.moving;
    }

    private void Update()
    {
        fish.Movement();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boat")
        {
            state = State.charging;

            fish.speed = -0.5f;

            fish.gameManager.DamageShip(fish.damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Boat")
        {
            state = State.attacking;

            StartCoroutine(ChargeAttack());
        }
    }

    IEnumerator ChargeAttack()
    {
        yield return new WaitForSeconds(0.5f);

        fish.speed = 1f;
    }
}
