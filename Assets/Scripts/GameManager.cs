using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject[] fish;
    public int money;
    public float moneyScaleValue;
    //money reward = levelNumber + fishRewardMultiplier * moneyScaleValue ^ levelNumber;

    [Header("Upgrade Info")]
    public float damageValue;// damage formula : damageValue * damageMultiplier
    public float fireRate;//fire rate formula : baseFireRate - fireRate * fireRateMultiplier
    public float shipHp;
    public float shipMaxHp;


    [Header("Level Settings")]
    public int levelNumber;
    public int numberOfFish;
    public GameObject[] fishList;


    public void Awake()
    {
        shipHp = shipMaxHp;
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        fishList = new GameObject[numberOfFish + 1];

        for (int i = 0; i < numberOfFish; i++)
        {
            float xPosition = Random.Range(-3f, 3f);
            float angle = Mathf.Atan(7 / Mathf.Abs(xPosition)) * 180 / Mathf.PI;
            int flipImage = xPosition > 0 ? 180 : 0;

            fishList[i] = Instantiate(fish[Random.Range(0, fish.Length)], new Vector3(xPosition, -6f, -1), Quaternion.Euler(0, flipImage, angle));
        }

        yield return null;
    }

    public void KillFish(float rewardMultiplier)
    {
        float levelMultiplier = Mathf.Pow(moneyScaleValue, levelNumber);

        money += levelNumber + (int) (rewardMultiplier * levelMultiplier);
    }

    public void WaveIsOver()
    {

        levelNumber++;

        StartCoroutine(SpawnWave());
    }

    public void DamageShip(float damage)
    {
        shipHp -= damage;
    }
}
