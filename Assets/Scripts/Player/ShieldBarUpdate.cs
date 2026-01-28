using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBarUpdate : MonoBehaviour
{
    public PlayerHealth Shield;


    //public Image[] images;

    public Image shield1, shield2, shield3, shield4, shield5, shield6;





    void Start()
    {
        // change to player health
        PlayerHealth Shield = GetComponent<PlayerHealth>();



        //images = FindObjectOfType<Canvas>().transform.GetComponentsInChildren<Image>();

        // Damn

    }

    // Update is called once per frame
    void Update()
    {
        //images = FindObjectOfType<Canvas>().transform.GetComponentsInChildren<Image>();

        shieldShow();


    }

    void shieldShow()
    {
        switch (Shield.shieldHealth)
        {
            case 0:
                shield1.gameObject.SetActive(false);
                shield2.gameObject.SetActive(false);
                shield3.gameObject.SetActive(false);
                shield4.gameObject.SetActive(false);
                shield5.gameObject.SetActive(false);
                shield6.gameObject.SetActive(false);
                break;
            case 1:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(false);
                shield3.gameObject.SetActive(false);
                shield4.gameObject.SetActive(false);
                shield5.gameObject.SetActive(false);
                shield6.gameObject.SetActive(false);
                break;
            case 2:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(false);
                shield4.gameObject.SetActive(false);
                shield5.gameObject.SetActive(false);
                shield6.gameObject.SetActive(false);
                break;
            case 3:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(true);
                shield4.gameObject.SetActive(false);
                shield5.gameObject.SetActive(false);
                shield6.gameObject.SetActive(false);
                break;
            case 4:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(true);
                shield4.gameObject.SetActive(true);
                shield5.gameObject.SetActive(false);
                shield6.gameObject.SetActive(false);
                break;
            case 5:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(true);
                shield4.gameObject.SetActive(true);
                shield5.gameObject.SetActive(true);
                shield6.gameObject.SetActive(false);
                break;
            case 6:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(true);
                shield4.gameObject.SetActive(true);
                shield5.gameObject.SetActive(true);
                shield6.gameObject.SetActive(true);
                break;
        }
    }
}
