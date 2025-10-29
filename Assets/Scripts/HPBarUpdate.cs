using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBarUpdate : MonoBehaviour
{
    public Death HP;


    public Image[] images;

    // public Image health1, health2, health3, health4, health5, health6, health7, health8, health9, health10, health11, health12;





    void Start()
    {

        Death HP = GetComponent<Death>();



        //images = FindObjectOfType<Canvas>().transform.GetComponentsInChildren<Image>();

        // Damn
        images[0].gameObject.SetActive(true);
        images[1].gameObject.SetActive(true);
        images[2].gameObject.SetActive(true);
        images[3].gameObject.SetActive(false);
        images[4].gameObject.SetActive(false);
        images[5].gameObject.SetActive(false);
        images[6].gameObject.SetActive(false);
        images[7].gameObject.SetActive(false);
        images[8].gameObject.SetActive(false);
        images[9].gameObject.SetActive(false);
        images[10].gameObject.SetActive(false);
        images[11].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        images = FindObjectOfType<Canvas>().transform.GetComponentsInChildren<Image>();

        healthShow();


    }

    void healthShow()
    {
        switch (HP.health)
        {
            case 0:
                images[0].gameObject.SetActive(false);
                images[1].gameObject.SetActive(false);
                images[2].gameObject.SetActive(false);
                images[3].gameObject.SetActive(false);
                images[4].gameObject.SetActive(false);
                images[5].gameObject.SetActive(false);
                images[6].gameObject.SetActive(false);
                images[7].gameObject.SetActive(false);
                images[8].gameObject.SetActive(false);
                images[9].gameObject.SetActive(false);
                images[10].gameObject.SetActive(false);
                images[11].gameObject.SetActive(false);
                break;
            case 1:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(false);
                images[2].gameObject.SetActive(false);
                images[3].gameObject.SetActive(false);
                images[4].gameObject.SetActive(false);
                images[5].gameObject.SetActive(false);
                images[6].gameObject.SetActive(false);
                images[7].gameObject.SetActive(false);
                images[8].gameObject.SetActive(false);
                images[9].gameObject.SetActive(false);
                images[10].gameObject.SetActive(false);
                images[11].gameObject.SetActive(false);
                break;
            case 2:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(true);
                images[2].gameObject.SetActive(false);
                images[3].gameObject.SetActive(false);
                images[4].gameObject.SetActive(false);
                images[5].gameObject.SetActive(false);
                images[6].gameObject.SetActive(false);
                images[7].gameObject.SetActive(false);
                images[8].gameObject.SetActive(false);
                images[9].gameObject.SetActive(false);
                images[10].gameObject.SetActive(false);
                images[11].gameObject.SetActive(false);
                break;
            case 3:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(true);
                images[2].gameObject.SetActive(true);
                images[3].gameObject.SetActive(false);
                images[4].gameObject.SetActive(false);
                images[5].gameObject.SetActive(false);
                images[6].gameObject.SetActive(false);
                images[7].gameObject.SetActive(false);
                images[8].gameObject.SetActive(false);
                images[9].gameObject.SetActive(false);
                images[10].gameObject.SetActive(false);
                images[11].gameObject.SetActive(false);
                break;
            case 4:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(true);
                images[2].gameObject.SetActive(true);
                images[3].gameObject.SetActive(true);
                images[4].gameObject.SetActive(false);
                images[5].gameObject.SetActive(false);
                images[6].gameObject.SetActive(false);
                images[7].gameObject.SetActive(false);
                images[8].gameObject.SetActive(false);
                images[9].gameObject.SetActive(false);
                images[10].gameObject.SetActive(false);
                images[11].gameObject.SetActive(false);
                break;
            case 5:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(true);
                images[2].gameObject.SetActive(true);
                images[3].gameObject.SetActive(true);
                images[4].gameObject.SetActive(true);
                images[5].gameObject.SetActive(false);
                images[6].gameObject.SetActive(false);
                images[7].gameObject.SetActive(false);
                images[8].gameObject.SetActive(false);
                images[9].gameObject.SetActive(false);
                images[10].gameObject.SetActive(false);
                images[11].gameObject.SetActive(false);
                break;
            case 6:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(true);
                images[2].gameObject.SetActive(true);
                images[3].gameObject.SetActive(true);
                images[4].gameObject.SetActive(true);
                images[5].gameObject.SetActive(true);
                images[6].gameObject.SetActive(false);
                images[7].gameObject.SetActive(false);
                images[8].gameObject.SetActive(false);
                images[9].gameObject.SetActive(false);
                images[10].gameObject.SetActive(false);
                images[11].gameObject.SetActive(false);
                break;
            case 7:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(true);
                images[2].gameObject.SetActive(true);
                images[3].gameObject.SetActive(true);
                images[4].gameObject.SetActive(true);
                images[5].gameObject.SetActive(true);
                images[6].gameObject.SetActive(true);
                images[7].gameObject.SetActive(false);
                images[8].gameObject.SetActive(false);
                images[9].gameObject.SetActive(false);
                images[10].gameObject.SetActive(false);
                images[11].gameObject.SetActive(false);
                break;
            case 8:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(true);
                images[2].gameObject.SetActive(true);
                images[3].gameObject.SetActive(true);
                images[4].gameObject.SetActive(true);
                images[5].gameObject.SetActive(true);
                images[6].gameObject.SetActive(true);
                images[7].gameObject.SetActive(true);
                images[8].gameObject.SetActive(false);
                images[9].gameObject.SetActive(false);
                images[10].gameObject.SetActive(false);
                images[11].gameObject.SetActive(false);
                break;
            case 9:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(true);
                images[2].gameObject.SetActive(true);
                images[3].gameObject.SetActive(true);
                images[4].gameObject.SetActive(true);
                images[5].gameObject.SetActive(true);
                images[6].gameObject.SetActive(true);
                images[7].gameObject.SetActive(true);
                images[8].gameObject.SetActive(true);
                images[9].gameObject.SetActive(false);
                images[10].gameObject.SetActive(false);
                images[11].gameObject.SetActive(false);
                break;
            case 10:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(true);
                images[2].gameObject.SetActive(true);
                images[3].gameObject.SetActive(true);
                images[4].gameObject.SetActive(true);
                images[5].gameObject.SetActive(true);
                images[6].gameObject.SetActive(true);
                images[7].gameObject.SetActive(true);
                images[8].gameObject.SetActive(true);
                images[9].gameObject.SetActive(true);
                images[10].gameObject.SetActive(false);
                images[11].gameObject.SetActive(false);
                break;
            case 11:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(true);
                images[2].gameObject.SetActive(true);
                images[3].gameObject.SetActive(true);
                images[4].gameObject.SetActive(true);
                images[5].gameObject.SetActive(true);
                images[6].gameObject.SetActive(true);
                images[7].gameObject.SetActive(true);
                images[8].gameObject.SetActive(true);
                images[9].gameObject.SetActive(true);
                images[10].gameObject.SetActive(true);
                images[11].gameObject.SetActive(false);
                break;
            case 12:
                images[0].gameObject.SetActive(true);
                images[1].gameObject.SetActive(true);
                images[2].gameObject.SetActive(true);
                images[3].gameObject.SetActive(true);
                images[4].gameObject.SetActive(true);
                images[5].gameObject.SetActive(true);
                images[6].gameObject.SetActive(true);
                images[7].gameObject.SetActive(true);
                images[8].gameObject.SetActive(true);
                images[9].gameObject.SetActive(true);
                images[10].gameObject.SetActive(true);
                images[11].gameObject.SetActive(true);
                break;
        }
    }
}
