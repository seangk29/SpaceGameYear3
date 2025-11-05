using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBarUpdate : MonoBehaviour
{
    public Death HP;


    //public Image[] images;

     public Image health1, health2, health3, health4, health5, health6, health7, health8, health9, health10, health11, health12;





    void Start()
    {

        Death HP = GetComponent<Death>();



        //images = FindObjectOfType<Canvas>().transform.GetComponentsInChildren<Image>();

        // Damn

    }

    // Update is called once per frame
    void Update()
    {
        //images = FindObjectOfType<Canvas>().transform.GetComponentsInChildren<Image>();

        healthShow();


    }

    void healthShow()
    {
        switch (HP.health)
        {
            case 0:
                health1.gameObject.SetActive(false);
                health2.gameObject.SetActive(false);
                health3.gameObject.SetActive(false);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                health6.gameObject.SetActive(false);
                health7.gameObject.SetActive(false);
                health8.gameObject.SetActive(false);
                health9.gameObject.SetActive(false);
                health10.gameObject.SetActive(false);
                health11.gameObject.SetActive(false);
                health12.gameObject.SetActive(false);
                break;
            case 1:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(false);
                health3.gameObject.SetActive(false);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                health6.gameObject.SetActive(false);
                health7.gameObject.SetActive(false);
                health8.gameObject.SetActive(false);
                health9.gameObject.SetActive(false);
                health10.gameObject.SetActive(false);
                health11.gameObject.SetActive(false);
                health12.gameObject.SetActive(false);
                break;
            case 2:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(false);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                health6.gameObject.SetActive(false);
                health7.gameObject.SetActive(false);
                health8.gameObject.SetActive(false);
                health9.gameObject.SetActive(false);
                health10.gameObject.SetActive(false);
                health11.gameObject.SetActive(false);
                health12.gameObject.SetActive(false);
                break;
            case 3:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                health6.gameObject.SetActive(false);
                health7.gameObject.SetActive(false);
                health8.gameObject.SetActive(false);
                health9.gameObject.SetActive(false);
                health10.gameObject.SetActive(false);
                health11.gameObject.SetActive(false);
                health12.gameObject.SetActive(false);
                break;
            case 4:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(false);
                health6.gameObject.SetActive(false);
                health7.gameObject.SetActive(false);
                health8.gameObject.SetActive(false);
                health9.gameObject.SetActive(false);
                health10.gameObject.SetActive(false);
                health11.gameObject.SetActive(false);
                health12.gameObject.SetActive(false);
                break;
            case 5:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(true);
                health6.gameObject.SetActive(false);
                health7.gameObject.SetActive(false);
                health8.gameObject.SetActive(false);
                health9.gameObject.SetActive(false);
                health10.gameObject.SetActive(false);
                health11.gameObject.SetActive(false);
                health12.gameObject.SetActive(false);
                break;
            case 6:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(true);
                health6.gameObject.SetActive(true);
                health7.gameObject.SetActive(false);
                health8.gameObject.SetActive(false);
                health9.gameObject.SetActive(false);
                health10.gameObject.SetActive(false);
                health11.gameObject.SetActive(false);
                health12.gameObject.SetActive(false);
                break;
            case 7:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(true);
                health6.gameObject.SetActive(true);
                health7.gameObject.SetActive(true);
                health8.gameObject.SetActive(false);
                health9.gameObject.SetActive(false);
                health10.gameObject.SetActive(false);
                health11.gameObject.SetActive(false);
                health12.gameObject.SetActive(false);
                break;
            case 8:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(true);
                health6.gameObject.SetActive(true);
                health7.gameObject.SetActive(true);
                health8.gameObject.SetActive(true);
                health9.gameObject.SetActive(false);
                health10.gameObject.SetActive(false);
                health11.gameObject.SetActive(false);
                health12.gameObject.SetActive(false);
                break;
            case 9:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(true);
                health6.gameObject.SetActive(true);
                health7.gameObject.SetActive(true);
                health8.gameObject.SetActive(true);
                health9.gameObject.SetActive(true);
                health10.gameObject.SetActive(false);
                health11.gameObject.SetActive(false);
                health12.gameObject.SetActive(false);
                break;
            case 10:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(true);
                health6.gameObject.SetActive(true);
                health7.gameObject.SetActive(true);
                health8.gameObject.SetActive(true);
                health9.gameObject.SetActive(true);
                health10.gameObject.SetActive(true);
                health11.gameObject.SetActive(false);
                health12.gameObject.SetActive(false);
                break;
            case 11:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(true);
                health6.gameObject.SetActive(true);
                health7.gameObject.SetActive(true);
                health8.gameObject.SetActive(true);
                health9.gameObject.SetActive(true);
                health10.gameObject.SetActive(true);
                health11.gameObject.SetActive(true);
                health12.gameObject.SetActive(false);
                break;
            case 12:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(true);
                health6.gameObject.SetActive(true);
                health7.gameObject.SetActive(true);
                health8.gameObject.SetActive(true);
                health9.gameObject.SetActive(true);
                health10.gameObject.SetActive(true);
                health11.gameObject.SetActive(true);
                health12.gameObject.SetActive(true);
                break;
        }
    }
}
