using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject target;

    [Header("Weapon Settings")]
    public GameObject projectile;
    public float fireRate;
    public float baseFireRate;
    public float fireRateMultiplier;
    public float maxFireRate;

    [Header("Angle Calculation")]
    public float opposite;
    public float adjacent;
    public float angle;
    public float flipImage;

    private float _timer;

    public void Awake()
    {
        fireRate = baseFireRate;
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    public void Update()
    {
        _timer += Time.deltaTime;

        if (target == null)
        {
            StartCoroutine(SetTarget());
        }

        if (target != null)
        {
            CalculateAngle();
        }

        CalculateFireRate();

        if (_timer > fireRate && target != null)
        {
            _timer = 0f;

            Instantiate(projectile, transform.position, Quaternion.Euler(0, flipImage, angle));
        }
    }

    private void CalculateFireRate()
    {
        fireRate = Mathf.Clamp(baseFireRate - fireRateMultiplier * gameManager.fireRate, maxFireRate, baseFireRate);
    }

    private void CalculateAngle()
    {
        opposite = Mathf.Abs(target.transform.position.x - transform.position.x);
        adjacent = transform.position.y + Mathf.Abs(target.transform.position.y);
        angle = Mathf.Atan(opposite / adjacent) * 180 / Mathf.PI;
        flipImage = target.transform.position.x > transform.position.x ? 0f : 180f;
    }

    IEnumerator SetTarget()
    {
        for (int i = 0; i < gameManager.fishList.Length; i++)
        {
            if (gameManager.fishList[i] != null)
            {
                if (target == null)
                {
                    target = gameManager.fishList[i];
                }
                else if (target.transform.position.y < gameManager.fishList[i].transform.position.y)
                {
                    target = gameManager.fishList[i];
                }
            }
        }

        if (target != null)
        {
            target.tag = "Target";
        }
        else
        {
            gameManager.WaveIsOver();
        }

        yield return null;
    }
}
