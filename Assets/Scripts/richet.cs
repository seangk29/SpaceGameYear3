using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class richet : MonoBehaviour
{

    public GameObject specialBulletPrefab;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "SpecialBullet")
        {
            specialBulletPrefab.transform.Rotate(0f, 0f, Random.Range(-90.0f, 90.0f));
        }
    }
}
