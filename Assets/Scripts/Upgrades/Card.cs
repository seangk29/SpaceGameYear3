using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer cardImageRenderer;
    [SerializeField] TextMeshPro cardTextRenderer;

    private CardSO cardInfo;

    public void Setup(CardSO card)
    { 
        cardInfo = card;
        cardImageRenderer.sprite = card.cardImage;
        cardTextRenderer.text = card.cardText;
    }

    private void OnMouseDown()
    {
        Debug.Log("You clicked it");
        CardManager.Instance.SelectCard(cardInfo);
    }
}
