using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardRemover : MonoBehaviour
{
   public CardManager cardManager;
    public List<CardSO> alreadySelectedCards = new List<CardSO>();

  
    private void Update()
    {
        if (cardManager == null)
        {
            cardManager = GameObject.FindGameObjectWithTag("cardManager").GetComponent<CardManager>();
        }
        else
            return;
    }

    private void HandleGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.CardSelection)
        {

            removeCard();
        }
    }


    public void removeCard()
    {
        List<CardSO> availableCards = new List<CardSO>(cardManager.Upgrades);
      
        // filtering upgrades
        availableCards.RemoveAll(card => card.isUnique && alreadySelectedCards.Contains(card) || card.unlockLevel > GameManager.Instance.GetCurrentLevel()
        );

    }
}
