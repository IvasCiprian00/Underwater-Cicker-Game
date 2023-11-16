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
    public TextMeshProUGUI fireRateUpgrade;
    public float damageScaleValue;
    public float fireRateScaleValue;

    public void Update()
    {
        depth.text = "Depth: " + gameManager.levelNumber + " m";
        wave.text = "Wave " + gameManager.waveNumber + "/4";

        damageUpgrade.text = "Damage\n +" + CalculateDamageDifference();
        fireRateUpgrade.text = "Fire Rate\n +" + fireRateScaleValue;
    }

    public void UpgradeDamage()
    {
        gameManager.damageValue *= damageScaleValue;
    }

    public void UpgradeFireRate()
    {
        gameManager.fireRate += fireRateScaleValue;
    }

    public float CalculateDamageDifference()
    {
        float nextDamageValue = gameManager.damageValue * damageScaleValue;
        float damageDifference = nextDamageValue - gameManager.damageValue;
        float damageRounded = Mathf.Round(damageDifference * 100f) / 100f;

        return damageRounded;
    }
}
