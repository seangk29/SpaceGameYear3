using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CardSelector : MonoBehaviour
{

    public int currentHovered;

    public GameObject CardCon1;
    public GameObject CardCon2;
    public GameObject CardCon3;

    public Card card;
    public CardManager CardManager;
    public GameManager gameManager;


    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentState == CardSelection)
        {
            switch (currentHovered)
            {
                case 1:
                    CardCon1.SetActive(true);
                    CardCon2.SetActive(false);
                    CardCon3.SetActive(false);
                    break;
                case 2:
                    CardCon2.SetActive(true);
                    CardCon1.SetActive(false);
                    CardCon3.SetActive(false);
                    break;
                case 3:
                    CardCon3.SetActive(true);
                    CardCon2.SetActive(false);
                    CardCon1.SetActive(false);
                    break;
            }

            if (currentHovered == 4)
                currentHovered = 1;
            if (currentHovered == 0)
                currentHovered = 3;

            if (Input.GetKeyDown(KeyCode.D))
            {
                currentHovered += 1;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentHovered -= 1;
            }
        }
    }
}
