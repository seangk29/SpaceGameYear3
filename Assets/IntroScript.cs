using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{


    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    public GameObject cosmoSign;
    public GameObject ships;
    public GameObject cover;
    public GameObject dialogue;

    public float timer;
    public float timeToShow;

    public int textCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToShow)
        {

            textCounter = textCounter + 1;

            switch(textCounter)
            {
                case 1:
                    text2.SetActive(true);
                    text1.SetActive(false);
                    timer = 0;
                    break;
                case 2:
                    text3.SetActive(true);
                    text2.SetActive(false);
                    timer = 0;
                    break;
                case 3:
                    text4.SetActive(true);
                    cover.SetActive(true);
                    text3.SetActive(false);
                    timer = 0;
                    break;
                case 4:
                    text4.SetActive(false);
                    cosmoSign.SetActive(true);
                    timer = 0;
                    break;
                case 5:
                    ships.SetActive(true);
                    dialogue.SetActive(true);
                    timer = 0;
                    break;
                case 6:
                    timer = 0;
                    break;
                case 7:
                    cosmoSign.SetActive(false);
                    timer = 0;
                    break;

            }
        }
    }
}
