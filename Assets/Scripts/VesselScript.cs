using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VesselScript : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject[] projectile;
    public int currentProjectile;
    public float fireRate;

    [Header("Angle Calculation")]
    public float opposite;
    public float adjacent;
    public float angle;
    public float flipImage;

    public GameManager gameManager;

    public GameObject target = null;

    private float _timer = 0f;

    public void Update()
    {
        _timer += Time.deltaTime;

        if(target == null)
        {
            StartCoroutine(SetTarget());
        }

        if(target != null)
        {
            CalculateAngle();
        }

        if(_timer > fireRate && target != null)
        {
            _timer = 0f;

            Instantiate(projectile[currentProjectile], transform.position, Quaternion.Euler(0, flipImage, angle));
        }
    }

    private void CalculateAngle()
    {
        opposite = Mathf.Abs(target.transform.position.x);
        adjacent = transform.position.y + Mathf.Abs(target.transform.position.y);
        angle = Mathf.Atan(opposite / adjacent) * 180 / Mathf.PI;
        flipImage = target.transform.position.x > 0 ? 0f : 180f;
    }

    IEnumerator SetTarget()
    {
        for(int i = 0; i < gameManager.fishList.Length; i++)
        {
            if (gameManager.fishList[i] != null)
            {
                if (target == null)
                {
                    target = gameManager.fishList[i];
                }
                else if(target.transform.position.y < gameManager.fishList[i].transform.position.y)
                {
                    target = gameManager.fishList[i];
                }
            }
        }

        if(target != null)
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
