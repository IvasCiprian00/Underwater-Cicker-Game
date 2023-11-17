using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameManager gameManager;

    private void Update()
    {
        slider.maxValue = gameManager.shipMaxHp;
        slider.value = gameManager.shipHp;
    }
}
