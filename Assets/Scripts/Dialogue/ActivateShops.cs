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
       
    }

    // Update is called once per frame
    void Update()
    {
        shops = GameObject.Find("Player").GetComponent<FindShop>();

        if (controller.convoEnded == true && shops.CompareTag("Skippy"))
        {
            skipsShop.SetActive(true);
        }
        else if (controller.convoEnded == true && shops.CompareTag("Nicos"))
        {
            nicosShop.SetActive(true);
        }

    }
}
