using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : ProjectileClass
{
    private void Awake()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        SetDamageMultiplier(1f);
        SetFireRateMultiplier(1f);
        SetSpeed(10f);
    }

    private void Update()
    {
        Movement();
        CheckOffscreen();
    }
}
