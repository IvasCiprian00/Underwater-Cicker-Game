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
    public GameObject[] menus;
    private int activeMenu = -1;

    [Header("Weapon Slots")]
    public GameObject[] weaponSlots;
    public bool[] slotIsFree;
    public GameObject selectedWeapon;

    [Header("Level Info")]
    public TextMeshProUGUI depth;

    [Header("Upgrades")]
    public TextMeshProUGUI damageUpgrade;
    public TextMeshProUGUI fireRateUpgrade;
    public TextMeshProUGUI hpUpgrade;
    public float damageScaleValue;
    public float fireRateScaleValue;
    public float hpScaleValue;

    [Header("Upgrade Costs")]
    public TextMeshProUGUI money;
    public TextMeshProUGUI damageCostText;
    public TextMeshProUGUI fireRateCostText;
    public TextMeshProUGUI hpCostText;
    public float upgradeCostScale;

    public int damageCost;
    public int fireRateCost;
    public int hpCost;

    [Header("Upgrade Levels")]
    public int damageLevel;
    public int fireRateLevel;
    public int hpLevel;

    [Header("Button Components")]
    public Button damageButton;
    public Button fireRateButton;
    public Button hpButton;

    public Image damageImage;
    public Image fireRateImage;
    public Image hpImage;

    public void Awake()
    {
        Vector3 weaponPosition = new Vector3(weaponSlots[0].transform.position.x, weaponSlots[0].transform.position.y, -1);
        vesselScript.weapons[0] = Instantiate(selectedWeapon, weaponPosition, Quaternion.identity, GameObject.Find("Boat").transform);

        slotIsFree[0] = false;
    }

    public void Update()
    {
        SetText();

        ButtonCostCheck();
    }

    private void SetText()
    {
        depth.text = "Depth: " + gameManager.levelNumber + " m";
        money.text = gameManager.money + "";

        damageUpgrade.text = "Damage\n +" + CalculateUpgradeDifference(gameManager.damageValue, damageScaleValue);
        fireRateUpgrade.text = "Fire Rate\n +" + fireRateScaleValue;
        hpUpgrade.text = "HP\n +" + CalculateUpgradeDifference(gameManager.shipMaxHp, hpScaleValue);

        damageCostText.text = damageCost + "";
        fireRateCostText.text = fireRateCost + "";
        hpCostText.text = hpCost + "";
    }

    private void ButtonCostCheck()
    {
        CheckUpgradeCost(damageCost, damageImage, damageButton, damageUpgrade);
        CheckUpgradeCost(fireRateCost, fireRateImage, fireRateButton, fireRateUpgrade);
        CheckUpgradeCost(hpCost, hpImage, hpButton, hpUpgrade);
    }

    //Button  related Functions

    public void CheckUpgradeCost(int upgradeCost, Image buttonImage, Button button, TextMeshProUGUI buttonText)
    {
        if(upgradeCost > gameManager.money)
        {
            button.enabled = false;
            buttonImage.color = Color.gray;
            buttonText.color = Color.black;

            return;
        }

        button.enabled = true;
        buttonImage.color = new Color32(3, 62, 140, 255);
        buttonText.color = new Color32(74, 255, 220, 255);
    }

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
        vesselScript.weapons[slotNumber] = Instantiate(selectedWeapon, weaponPosition, Quaternion.identity, GameObject.Find("Boat").transform);

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

        UpdateMoney(damageCost);
        UpdateCost(ref damageCost, ref damageLevel);

        CancelSelection();
    }

    public void UpgradeFireRate()
    {
        gameManager.fireRate += fireRateScaleValue;

        UpdateMoney(fireRateCost);
        UpdateCost(ref fireRateCost, ref fireRateLevel);

        CancelSelection();
    }

    public void UpgradeHP()
    {
        gameManager.shipHp *= hpScaleValue;
        gameManager.shipMaxHp *= hpScaleValue;

        UpdateMoney(hpCost);
        UpdateCost(ref hpCost, ref hpLevel);

        CancelSelection();
    }

    public void UpdateMoney(int x)
    {
        gameManager.money -= x;
    }

    public void UpdateCost(ref int cost, ref int level)
    {
        cost += level + (int)(upgradeCostScale * cost);
        level++;
    }

    public float CalculateUpgradeDifference(float x, float y)
    {
        float nextDamageValue = x * y;
        float damageDifference = nextDamageValue - x;
        float damageRounded = Mathf.Round(damageDifference * 100f) / 100f;

        return damageRounded;
    }
}