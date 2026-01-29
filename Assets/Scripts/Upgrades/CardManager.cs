using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // the selection thing that gets turned on and off
    [SerializeField] GameObject cardSelectionUI;

    // im gonna have to make every single upgrade card a prefab i think? thats fine
    [SerializeField] GameObject cardPrefab;

    [SerializeField] Transform cardPositionOne;
    [SerializeField] Transform cardPositionTwo;
    [SerializeField] Transform cardPositionThree;

    [SerializeField] List<CardSO> Upgrades;

    // Currently randomized cards go here
    GameObject cardOne, cardTwo, cardThree;

    List<CardSO> alreadySelectedCards = new List<CardSO>();

    public static CardManager Instance;

    public static PlayerHealth PlayerHealth;

    private void Start()
    {
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void Awake()
    {
        Instance = this;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged -= HandleGameStateChanged;
        }
    }

    private void HandleGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.CardSelection)
        {
            RandomizeNewCards();
        }
    }
    void RandomizeNewCards()
    {
        if (cardOne != null) Destroy(cardOne);
        if (cardTwo != null) Destroy(cardTwo);
        if (cardThree != null) Destroy(cardThree);

        List<CardSO> randomizedCards = new List<CardSO>();

        List<CardSO> availableCards = new List<CardSO>(Upgrades);
        availableCards.RemoveAll(card =>
            card.isUnique && alreadySelectedCards.Contains(card)
            || card.unlockLevel > GameManager.Instance.GetCurrentLevel()
        );

        if (availableCards.Count < 3)
        {
            Debug.Log("not enough available cards");
            return;
        }

        while (randomizedCards.Count < 3)
        {
            CardSO randomCard = availableCards[Random.Range(0, availableCards.Count)];
            if (!randomizedCards.Contains(randomCard))
            {
                randomizedCards.Add(randomCard);
            }
        }

        cardOne = InstantiateCard(randomizedCards[0], cardPositionOne);
        cardTwo = InstantiateCard(randomizedCards[1], cardPositionTwo);
        cardThree = InstantiateCard(randomizedCards[2], cardPositionThree);
    }

    GameObject InstantiateCard(CardSO cardSO, Transform position)
    {
        GameObject cardGO = Instantiate(cardPrefab, position.position, Quaternion.identity, position);
        Card card = cardGO.GetComponent<Card>();
        card.Setup(cardSO);
        return cardGO;
    }

    public void SelectCard(CardSO selectedCard)
    {
        if (!alreadySelectedCards.Contains(selectedCard))
        { 
            alreadySelectedCards.Add(selectedCard);
        }

        // try and actually apply upgrade? itd be awesome if 
        switch (selectedCard)
        {
            case CardEffect.HpIncrease:
                return;
        }

        GameManager.Instance.changeState(GameManager.GameState.Playing);
    }

    public void ShowCardSelection()
    { 
        cardSelectionUI.SetActive(true);
    }

    public void HideCardSelection()
    {
        cardSelectionUI.SetActive(false);
    }
}
