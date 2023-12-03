using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JellyfishMovement : MonoBehaviour
{
    public Fish fish;

    public bool isAttached;

    private float t;

    private float timer;

    private IEnumerator Start()
    {
        while(true)
        {
            fish.speed = 1.9f;
            yield return new WaitForSeconds(0.3f);
            fish.speed = 0.9f;
            yield return new WaitForSeconds(0.3f);
            fish.speed = 0.4f;
            yield return new WaitForSeconds(0.3f);
            fish.speed = 0.1f;
            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {
        if(!isAttached)
        {
            fish.Movement();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boat")
        {
            isAttached = true;

            transform.SetParent(GameObject.Find("Boat_Sprite").transform);

            StartCoroutine(AttackBoat());
        }
    }

    IEnumerator AttackBoat()
    {
        while(gameObject != null)
        {
            fish.gameManager.DamageShip(fish.damage);

            yield return new WaitForSeconds(2f);
        }
    }
}
