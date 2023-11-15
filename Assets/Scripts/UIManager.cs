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


    public void Update()
    {
        depth.text = "Depth: " + gameManager.levelNumber + " m";
        wave.text = "Wave " + gameManager.waveNumber + "/4";
    }
}
