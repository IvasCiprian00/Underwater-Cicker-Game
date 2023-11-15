using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFish : FishClass
{
    
    void Awake()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if(gameManager.levelNumber == 1)
        {
            SetHP(1);
            SetDamage(1);
        }
        else
        {
            SetDamage(1 * Mathf.Pow(GetScaleValue(), gameManager.levelNumber - 1));
            SetHP(1 * Mathf.Pow(GetScaleValue(), gameManager.levelNumber - 1));
        }
        SetSpeed(Random.Range(0.9f, 1.1f));
    }

    private void Update()
    {
        Movement();
        if(GetHP() <= 0)
        {
            Destroy(gameObject);
        }
    }
}
