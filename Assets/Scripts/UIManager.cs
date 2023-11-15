using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager: MonoBehaviour
{
    public GameManager gameManager;

    [Header("Level Info")]
    public TextMeshProUGUI depth;
    public TextMeshProUGUI wave;

    [Header("Upgrades")]
    public TextMeshProUGUI damageUpgrade;
    public float upgradeScaleValue;

    public void Update()
    {
        depth.text = "Depth: " + gameManager.levelNumber + " m";
        wave.text = "Wave " + gameManager.waveNumber + "/4";

        damageUpgrade.text = "Damage\n +" + CalculateDamageDifference();
    }

    public void UpgradeDamage()
    {
        gameManager.damageValue *= upgradeScaleValue;
    }

    public float CalculateDamageDifference()
    {
        float nextDamageValue = gameManager.damageValue * upgradeScaleValue;
        float damageDifference = nextDamageValue - gameManager.damageValue;
        float damageRounded = Mathf.Round(damageDifference * 100f) / 100f;

        return damageRounded;
    }
}
