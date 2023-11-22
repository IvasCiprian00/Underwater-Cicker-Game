using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public Fish fish;

    enum State
    {
        prowling,
        attacking
    }

    private State state;

    private void Awake()
    {
        fish.SetSpeed(Random.Range(2f, 3f));

        state = State.attacking;
    }

    private void Update()
    {
        if(state == State.attacking)
        {
            fish.Movement();
        }
    }
}
