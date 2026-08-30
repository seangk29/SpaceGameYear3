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
    public Animator c1Animator;
    public Card card2;
    public Animator c2Animator;
    public Card card3;
    public Animator c3Animator;

    public CardManager cardManager;
    public GameManager gameManager;

    public bool acceptUpgrade = false;
    public bool animCheck = true;

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
        if (card1 == null && card2 == null && card3 == null)
        {
            card1 = GameObject.FindGameObjectWithTag("card1").GetComponentInChildren<Card>();
            c1Animator = GameObject.FindGameObjectWithTag("card1").GetComponentInChildren<Animator>();

            card2 = GameObject.FindGameObjectWithTag("card2").GetComponentInChildren<Card>();
            c2Animator = GameObject.FindGameObjectWithTag("card2").GetComponentInChildren<Animator>();

            card3 = GameObject.FindGameObjectWithTag("card3").GetComponentInChildren<Card>();
            c3Animator = GameObject.FindGameObjectWithTag("card3").GetComponentInChildren<Animator>();
        }


        c1Animator.SetTrigger("OffScreen");
        c2Animator.SetTrigger("OffScreen"); 
        c3Animator.SetTrigger("OffScreen");

    }

    private void Update()
    {
        if (gameManager.currentState == GameManager.GameState.CardSelection)
        {

            cardCheck();
            //controls.Gameplay.Enable();
            if (currentHovered <= 0) currentHovered = 3;
            if (currentHovered >= 4) currentHovered = 1;

            MoveLeft();
            MoveRight();

            if (card1 == null && card2 == null && card3 == null)
            {
                card1 = GameObject.FindGameObjectWithTag("card1").GetComponentInChildren<Card>();
                c1Animator = GameObject.FindGameObjectWithTag("card1").GetComponentInChildren<Animator>();

                card2 = GameObject.FindGameObjectWithTag("card2").GetComponentInChildren<Card>();
                c2Animator = GameObject.FindGameObjectWithTag("card2").GetComponentInChildren<Animator>();

                card3 = GameObject.FindGameObjectWithTag("card3").GetComponentInChildren<Card>();
                c3Animator = GameObject.FindGameObjectWithTag("card3").GetComponentInChildren<Animator>();
            }

            switch (currentHovered)
            {
                case 1:
                    card1.currentlySelected = true;
                    card2.currentlySelected = false;
                    card3.currentlySelected = false;
                    card1.changeSelection();
                    c1Animator.SetTrigger("Selected");
                    c2Animator.SetTrigger("Idle");
                    c3Animator.SetTrigger("Idle");
                    break;
                case 2:
                    card1.currentlySelected = false;
                    card2.currentlySelected = true;
                    card3.currentlySelected = false;
                    card2.changeSelection();
                    c1Animator.SetTrigger("Idle");
                    c2Animator.SetTrigger("Selected");
                    c3Animator.SetTrigger("Idle");
                    break;
                case 3:
                    card1.currentlySelected = false;
                    card2.currentlySelected = false;
                    card3.currentlySelected = true;
                    card3.changeSelection();
                    c1Animator.SetTrigger("Idle");
                    c2Animator.SetTrigger("Idle");
                    c3Animator.SetTrigger("Selected");
                    break;
            }

           
        }


        if (acceptUpgrade == true)
        {

            c1Animator.SetTrigger("OffScreen");
            c2Animator.SetTrigger("OffScreen");
            c3Animator.SetTrigger("OffScreen");

         
        }
    }

    void cardCheck()
    {
        if (gameManager.currentState == GameManager.GameState.CardSelection && animCheck)
        {
            c1Animator.SetTrigger("Idle");
            c2Animator.SetTrigger("Idle");
            c3Animator.SetTrigger("Idle");
            animCheck = false;

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
