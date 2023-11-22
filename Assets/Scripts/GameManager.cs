using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject[] fish;
    public GameObject[] fishBosses;

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
            float xPosition = 0f;
            float angle = 0f;
            int flipImage = 0;

            CalculateTransform(ref xPosition, ref angle, ref flipImage);

            fishList[i] = Instantiate(fish[Random.Range(0, fish.Length)], new Vector3(xPosition, -6f, -1), Quaternion.Euler(0, flipImage, angle));
        }

        yield return null;
    }

    IEnumerator SpawnBoss()
    {
        fishList = new GameObject[1];

        float xPosition = 0f;
        float angle = 0f;
        int flipImage = 0;

        CalculateTransform(ref xPosition, ref angle, ref flipImage);

        fishList[0] = Instantiate(fishBosses[0], new Vector3(xPosition, -6f, -1), Quaternion.Euler(0, flipImage, angle));

        yield return null;
    }

    public void CalculateTransform(ref float x, ref float y, ref int z)
    {
        x = Random.Range(-3f, 3f);
        y = Mathf.Atan(7 / Mathf.Abs(x)) * 180 / Mathf.PI;
        z = x > 0 ? 180 : 0;
    }

    public void KillFish(float rewardMultiplier)
    {
        float levelMultiplier = Mathf.Pow(moneyScaleValue, levelNumber);

        money += levelNumber + (int) (rewardMultiplier * levelMultiplier);
    }

    public void WaveIsOver()
    {

        levelNumber++;
        if(levelNumber % 10 == 0)
        {
            StartCoroutine(SpawnBoss());
            return;
        }

        StartCoroutine(SpawnWave());
    }

    public void DamageShip(float damage)
    {
        shipHp -= damage;
    }
}
