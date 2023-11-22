using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public Fish fish;

    enum State
    {
        prowling,
        attacking,
        retreating
    }

    private State state;

    private float timer;

    private void Awake()
    {
        fish.SetSpeed(7f);

        state = State.attacking;
    }

    private void Update()
    {
        fish.Movement();

        if(state == State.retreating && transform.position.y < -4f) 
        {
            state = State.prowling;
            fish.speed = 1.3f;
            timer = 0f;

            transform.rotation = (Random.Range(1, 3) == 1) ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
        }

        if(state == State.prowling)
        {
            if(transform.position.x < -2.5f)
            {
                transform.rotation = Quaternion.identity;
            }

            if(transform.position.x > 2.5f)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            timer += Time.deltaTime;
        }

        if(timer > 5f && state == State.prowling)
        {
            state = State.attacking;

            float angle = Mathf.Atan(7 / Mathf.Abs(transform.position.x)) * 180 / Mathf.PI;
            int flipImage = transform.position.x > 0 ? 180 : 0;

            fish.speed = 7f;

            transform.rotation = Quaternion.Euler(0, flipImage, angle);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boat")
        {
            fish.gameManager.DamageShip(fish.damage);
            transform.rotation = Quaternion.Euler(0, 0, -90);
            fish.SetSpeed(4f);
            state = State.retreating;
        }
    }
}
