using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FishClass : MonoBehaviour
{
    [Header("Scaling Settings")]
    public GameManager gameManager;
    private float scaleValue = 1.15f;

    [Header("Fish Attributes")]
    public float speed;
    public float damage;
    public float hp;

    /*public FishClass(float scaleValue, float speed, float damage, float hp)
    {
        this.scaleValue = scaleValue;
        this.speed = speed;
        this.damage = damage;
        this.hp = hp;
    }*/

    public void SetScaleValue(float value)
    {
        scaleValue = value;
    }

    public float GetScaleValue() { 
        return scaleValue; 
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public float GetHP()
    {
        return this.hp;
    }
    public void SetHP(float hp)
    {
        this.hp = hp;
    }

    public void TakeDamage(float damage)
    {
        this.hp -= damage;
    }

    public void Movement() { 
        transform.Translate(Vector3.right * this.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boat")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Bullet" && gameObject.tag == "Target") 
        {
            BasicBullet bullet = collision.GetComponent<BasicBullet>();

            TakeDamage(bullet.GetDamage());
            Destroy(collision.gameObject);
        }
    }

    private void Awake()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }
}
