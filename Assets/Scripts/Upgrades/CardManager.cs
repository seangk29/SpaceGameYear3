using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GameManager;

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

    public static PermaPlayerStats PermaPlayerStats;

    private void Start()
    {
        PermaPlayerStats = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();
    }
    private void Awake()
    {
        Instance = this;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }
    }

    private void FixedUpdate()
    {

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }

        /*if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RandomizeNewCards();
            Debug.Log("bbbbbb");
        }*/
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

        var selectedCardType = selectedCard.effectType;
        var selectedCardValue = selectedCard.effectValue;

        // try and actually apply upgrade? itd be awesome if it works
       switch (selectedCardType)
        {
            case CardEffect.HpIncrease:
                PermaPlayerStats.MaxHealthUpgrade(selectedCardValue);
                break;
            case CardEffect.ShieldIncrease:
                PermaPlayerStats.MaxShieldUpgrade(selectedCardValue);
                break;
            case CardEffect.ShieldRegenIncrease:
                //upgrade
                break;
            case CardEffect.SpeedIncrease:
                PermaPlayerStats.MaxSpeedUpgrade(selectedCardValue);
                break;
            case CardEffect.SpreadUnlock:
                PermaPlayerStats.spreadUnlock();
                break;
            case CardEffect.RicochetUnlock:
                PermaPlayerStats.ricochetUnlock();
                break;
            case CardEffect.ExplodeUnlock:
                PermaPlayerStats.explodeUnlock();
                break;
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
