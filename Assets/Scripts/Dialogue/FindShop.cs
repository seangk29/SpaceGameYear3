using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FindShop : MonoBehaviour
{


    public GameObject npcShopable;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.CompareTag("Skippy"))
        {
            npcShopable = collision.gameObject;
        }
        else if (collision.gameObject.transform.CompareTag("Nicos"))
        {
            npcShopable = collision.gameObject;
        }
    }

}
