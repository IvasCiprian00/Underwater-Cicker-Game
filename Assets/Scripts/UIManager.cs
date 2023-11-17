using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class UIManager: MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI shipHp;
    public GameObject[] menus;
    private int activeMenu = -1;

    [Header("Level Info")]
    public TextMeshProUGUI depth;
    public TextMeshProUGUI wave;

    [Header("Upgrades")]
    public TextMeshProUGUI damageUpgrade;
    public TextMeshProUGUI fireRateUpgrade;
    public TextMeshProUGUI hpUpgrade;
    public float damageScaleValue;
    public float fireRateScaleValue;
    public float hpScaleValue;

    public void Update()
    {
        depth.text = "Depth: " + gameManager.levelNumber + " m";
        wave.text = "Wave " + gameManager.waveNumber + "/4";

        damageUpgrade.text = "Damage\n +" + CalculateUpgradeDifference(gameManager.damageValue, damageScaleValue);
        fireRateUpgrade.text = "Fire Rate\n +" + fireRateScaleValue;
        hpUpgrade.text = "HP\n +" + CalculateUpgradeDifference(gameManager.shipMaxHp, hpScaleValue);

        shipHp.text = gameManager.shipHp + "/" + gameManager.shipMaxHp;
    }

    public void ClickMenu(int menuNumber)
    {
        if(activeMenu == menuNumber)
        {
            menus[menuNumber].SetActive(false);
            activeMenu = -1;
            return;
        }

        if(activeMenu == -1)
        {
            menus[menuNumber].SetActive(true);
            activeMenu = menuNumber;
            return;
        }
        menus[activeMenu].SetActive(false);
        menus[menuNumber].SetActive(true);
        activeMenu = menuNumber;
    }

    public void UpgradeDamage()
    {
        gameManager.damageValue *= damageScaleValue;
    }

    public void UpgradeFireRate()
    {
        gameManager.fireRate += fireRateScaleValue;
    }

    public void UpgradeHP()
    {
        gameManager.shipHp *= hpScaleValue;
        gameManager.shipMaxHp *= hpScaleValue;
    }

    public float CalculateUpgradeDifference(float x, float y)
    {
        float nextDamageValue = x * y;
        float damageDifference = nextDamageValue - x;
        float damageRounded = Mathf.Round(damageDifference * 100f) / 100f;

        return damageRounded;
    }
}
