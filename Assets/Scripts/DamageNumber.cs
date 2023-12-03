using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public TextMeshProUGUI text;

    private int x = 255;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }


    private void Update()
    {
        transform.Translate(transform.up * Time.deltaTime);

        text.color = new Color32(0, 0, 0, (byte) x);

        x--;
    }
}
