using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class UIManager: MonoBehaviour
{

    public GameManager gameManager;
    public VesselScript vesselScript;
    public TextMeshProUGUI shipHp;
    public GameObject[] menus;
    private int activeMenu = -1;

    [Header("Weapon Slots")]
    public GameObject[] weaponSlots;
    public bool[] slotIsFree;
    public GameObject selectedWeapon;

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

    //Button Functions

    public void ClickMenu(int menuNumber)
    {
        CancelSelection();

        if (activeMenu == menuNumber)
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

    public void EquipWeapon(int slotNumber)
    {
        if(selectedWeapon == null)
        {
            return;
        }

        for(int i = 0; i < 4; i++)
        {
            if (vesselScript.weapons[i] != null)
            {
                if (selectedWeapon.name + "(Clone)" == vesselScript.weapons[i].name)
                {
                    Destroy(vesselScript.weapons[i]);
                    slotIsFree[i] = true;
                }
            }
        }

        Vector3 weaponPosition = new Vector3(weaponSlots[slotNumber].transform.position.x, weaponSlots[slotNumber].transform.position.y, -1);
        vesselScript.weapons[slotNumber] = Instantiate(selectedWeapon, weaponPosition, Quaternion.identity);

        slotIsFree[slotNumber] = false;

        CancelSelection();
        
    }

    public void SelectWeapon(GameObject weapon)
    {
        for(int i = 0; i < 4; i++)
        {
            if (slotIsFree[i])
            {
                weaponSlots[i].SetActive(true);
            }
        }
        weaponSlots[4].SetActive(true);

        selectedWeapon = weapon;
    }

    public void CancelSelection()
    {
        if (selectedWeapon == null)
        {
            return;
        }

        selectedWeapon = null;

        for(int i = 0; i < 4; i++) 
        {
            if (weaponSlots[i].activeSelf)
            {
                weaponSlots[i].SetActive(false);
            }
        }
        weaponSlots[4].SetActive(false);
    }

    public void UpgradeDamage()
    {
        gameManager.damageValue *= damageScaleValue;

        CancelSelection();
    }

    public void UpgradeFireRate()
    {
        gameManager.fireRate += fireRateScaleValue;

        CancelSelection();
    }

    public void UpgradeHP()
    {
        gameManager.shipHp *= hpScaleValue;
        gameManager.shipMaxHp *= hpScaleValue;

        CancelSelection();
    }

    public float CalculateUpgradeDifference(float x, float y)
    {
        float nextDamageValue = x * y;
        float damageDifference = nextDamageValue - x;
        float damageRounded = Mathf.Round(damageDifference * 100f) / 100f;

        return damageRounded;
    }
}
