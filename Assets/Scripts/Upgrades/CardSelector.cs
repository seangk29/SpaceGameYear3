using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;


public class CardSelector : MonoBehaviour
{
    public int currentHovered;

    public Card card1;
    public Card card2;
    public Card card3;

    public CardManager cardManager;
    public GameManager gameManager;




    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.UILeft.performed += ctx => MoveLeft();
        controls.Gameplay.UIRight.performed += ctx => MoveRight();

        gameManager = GameObject.FindGameObjectWithTag("GameMg").GetComponentInChildren<GameManager>();
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Start()
    {
        

        
    }

    private void Update()
    {
        if (gameManager.currentState == GameManager.GameState.CardSelection)
        {
            //controls.Gameplay.Enable();
            if (currentHovered <= 0) currentHovered = 3;
            if (currentHovered >= 4) currentHovered = 1;

            MoveLeft();
            MoveRight();

            if (card1 == null && card2 == null && card3 == null)
            {
                card1 = GameObject.FindGameObjectWithTag("card1").GetComponentInChildren<Card>();
                card2 = GameObject.FindGameObjectWithTag("card2").GetComponentInChildren<Card>();
                card3 = GameObject.FindGameObjectWithTag("card3").GetComponentInChildren<Card>();
            }

            switch (currentHovered)
            {
                case 1:
                    card1.currentlySelected = true;
                    card2.currentlySelected = false;
                    card3.currentlySelected = false;
                    card1.changeSelection();
                    break;
                case 2:
                    card1.currentlySelected = false;
                    card2.currentlySelected = true;
                    card3.currentlySelected = false;
                    card2.changeSelection();
                    break;
                case 3:
                    card1.currentlySelected = false;
                    card2.currentlySelected = false;
                    card3.currentlySelected = true;
                    card3.changeSelection();
                    break;
            }
        }
    }

    void MoveLeft()
    {
       // if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || controls.Gameplay.UILeft.IsPressed()) currentHovered += 1;
        currentHovered -= 1;
    }

    void MoveRight()
    {
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow) || controls.Gameplay.UIRight.IsPressed()) currentHovered -= 1;
        currentHovered += 1;

    }

    public void disableUIControls()
    {
        //controls.Gameplay.Disable();
    }


    // Update is called once per frame
    /*void Update()
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
    }*/
}
