using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : ProjectileClass
{
    private void Awake()
    {
        SetDamage(1);
        SetSpeed(10f);
    }

    private void Update()
    {
        Movement();
        CheckOffscreen();
    }
}
