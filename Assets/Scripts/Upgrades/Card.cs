using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer cardImageRenderer;
    [SerializeField] TextMeshPro cardHeaderRenderer;
    [SerializeField] TextMeshPro cardTextRenderer;
    [SerializeField] TextMeshPro cardDescRenderer;

    public GameObject currentlySelectedIndicator;
    public bool currentlySelected;

    private CardSO cardInfo;

    PlayerControls controls;
    CardSelector cardSelector;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameMg").GetComponent<GameManager>();

        controls = new PlayerControls();
        controls.Gameplay.UIAccept.performed += ctx => AcceptUpgrade();
    }

    public void Setup(CardSO card)
    { 
        cardInfo = card;
        cardImageRenderer.sprite = card.cardImage;
        cardHeaderRenderer.text = card.headerText;
        cardTextRenderer.text = card.cardText;
        cardDescRenderer.text = card.descText;

       
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Update()
    {
        if (currentlySelected)
            currentlySelectedIndicator.SetActive(true);
        else
            currentlySelectedIndicator.SetActive(false);

        
    }

    public void OnMouseDown()
    {
        if (currentlySelected)
        {
            Debug.Log("You clicked it");
            CardManager.Instance.SelectCard(cardInfo);
        }
    }

    public void OnSelect()
    {
        //controls.Gameplay.Disable();
        //cardSelector.disableUIControls();
        Debug.Log("You selected it");
        CardManager.Instance.SelectCard(cardInfo);
    }

    public void changeSelection()
    { 
        if (currentlySelected)
            currentlySelectedIndicator.SetActive(true);
        else
            currentlySelectedIndicator.SetActive(false);
    }

    void AcceptUpgrade()
    {

        if (gameManager.currentState == GameManager.GameState.CardSelection)
        {
            OnSelect();
        }


       
    }

}
