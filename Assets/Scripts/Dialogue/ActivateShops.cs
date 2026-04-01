using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShops : MonoBehaviour
{
    public DialogueController controller;
    public FindShop shops;

    public GameObject skipsShop;
    public GameObject nicosShop;

    // Start is called before the first frame update
    void Start()
    {
            shops = GameObject.Find("Player").GetComponent<FindShop>();

    }

    // Update is called once per frame
    void Update()
    {


        if (shops == null)
        {
            shops = GameObject.Find("Player").GetComponent<FindShop>();
        }
        else
            return;

        if (controller.convoEnded == true && shops.npcShopable.CompareTag("Skippy"))
        {
            skipsShop.SetActive(true);
        }
        else if (controller.convoEnded == true && shops.npcShopable.CompareTag("Nicos"))
        {
            nicosShop.SetActive(true);
        }

    }
}
