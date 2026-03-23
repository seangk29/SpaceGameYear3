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

    public void Setup(CardSO card)
    { 
        cardInfo = card;
        cardImageRenderer.sprite = card.cardImage;
        cardHeaderRenderer.text = card.headerText;
        cardTextRenderer.text = card.cardText;
        cardDescRenderer.text = card.descText;

        //controls = new PlayerControls();
        //controls.Gameplay.Enable();
    }

    private void Update()
    {
        if (currentlySelected)
            currentlySelectedIndicator.SetActive(true);
        else
            currentlySelectedIndicator.SetActive(false);

        if (currentlySelected && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)/* || currentlySelected && controls.Gameplay.UIAccept.IsPressed()*/)
            OnSelect();
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
}
