using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject[] fish;

    public int levelNumber;

    [Header("Wave Settings")]
    public int numberOfFish;
    public int waveNumber;
    public GameObject[] fishList;


    public void Start()
    {
        waveNumber = 1;
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

    public void WaveIsOver()
    {
        if(waveNumber == 4)
        {
            levelNumber++;
            waveNumber = 1;
            StartCoroutine(SpawnWave());
            return;
        }

        waveNumber++;
        StartCoroutine(SpawnWave());
    }
}
