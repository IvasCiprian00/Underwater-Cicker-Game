using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fish : MonoBehaviour
{
    [Header("Scaling Settings")]
    public GameManager gameManager;
    private float scaleValue = 1.15f;

    [Header("Fish Attributes")]
    public float speed;
    public float damage;
    public float hp;
    public float killRewardMultiplier;

    void Awake()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (gameManager.levelNumber > 1)
        {
            SetDamage(damage * Mathf.Pow(GetScaleValue(), gameManager.levelNumber - 1));
            SetHP(hp * Mathf.Pow(GetScaleValue(), gameManager.levelNumber - 1));
        }
    }

    private void Update()
    {
        if (GetHP() <= 0)
        {
            Destroy(gameObject);

            gameManager.KillFish(killRewardMultiplier);
        }
    }

    public void TakeDamage(float damage)
    {
        this.hp -= damage;
    }

    public void Movement()
    {
        transform.Translate(Vector3.right * this.speed * Time.deltaTime);
    }


    //  Basic class methods

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
        return hp;
    }
    public void SetHP(float hp)
    {
        this.hp = hp;
    }
}
