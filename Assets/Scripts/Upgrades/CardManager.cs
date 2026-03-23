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

    public GameObject cardGO1;
    public GameObject cardGO2;
    public GameObject cardGO3;

    [SerializeField] List<CardSO> Upgrades;

    // Currently randomized cards go here
    GameObject cardOne, cardTwo, cardThree;

    List<CardSO> alreadySelectedCards = new List<CardSO>();

    public static CardManager Instance;

    public static PermaPlayerStats PermaPlayerStats;
    public static PlayerMovement move;
    public static PlayerShooting shoot;
    public static ApplyUpgrades applyUpgrades;

    public CardEffect selectedCardType;
    public int selectedCardValue;


    private void Start()
    {
        PermaPlayerStats = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();
        applyUpgrades = GetComponent<ApplyUpgrades>();

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

        /*if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }*/

        if (shoot == null)
        {
            shoot = GameObject.FindGameObjectWithTag("GunPos").GetComponent<PlayerShooting>();
        }

        if (move == null)
        {
            move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
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

    public void RandomizeNewCards()
    {
        // kill upgrade objects if theyre already there
        // dont need this anymore actually but if its needed in future here you go
        //if (cardOne != null) Destroy(cardOne);
        //if (cardTwo != null) Destroy(cardTwo);
        //if (cardThree != null) Destroy(cardThree);

        List<CardSO> randomizedCards = new List<CardSO>();
        List<CardSO> availableCards = new List<CardSO>(Upgrades);

        // filtering upgrades
        availableCards.RemoveAll(card =>
            card.isUnique && alreadySelectedCards.Contains(card)
            || card.unlockLevel > GameManager.Instance.GetCurrentLevel()
        );

        // if theres less than 3 available cards. dont think this should ever happen now. you never know.
        if (availableCards.Count < 3)
        {
            Debug.Log("not enough available cards");
            return;
        }

        // randomising upgrades
       while (randomizedCards.Count < 3)
       //for (int i = 0; i < 4; i++) 
        {
            Debug.Log("Joanne - 3"); // I THINK THE PROBLEM IS HERE?
            CardSO randomCard = availableCards[Random.Range(0, availableCards.Count)];
            if (!randomizedCards.Contains(randomCard))
            {
                randomizedCards.Add(randomCard);
            }
          
        }

            // instantiate upgrade cards
            cardOne = InstantiateCard(randomizedCards[0], cardPositionOne, cardGO1);
            cardTwo = InstantiateCard(randomizedCards[1], cardPositionTwo, cardGO2);
            cardThree = InstantiateCard(randomizedCards[2], cardPositionThree, cardGO3);
    }

    // instantiating upgrade cards but for real
    GameObject InstantiateCard(CardSO cardSO, Transform position, GameObject cardGO)
    {
        //GameObject cardGO = Instantiate(cardPrefab, position.position, Quaternion.identity, position);
        Card card = cardGO.GetComponent<Card>();
        card.Setup(cardSO);
        return cardGO;
    }

    // selecting the card some of this is written 100% by me but it works in its own scene which makes
    // the memory overflow issue weird
    public void SelectCard(CardSO selectedCard)
    {
        if (!alreadySelectedCards.Contains(selectedCard))
        { 
            alreadySelectedCards.Add(selectedCard);
        }

        selectedCardType = selectedCard.effectType;
        selectedCardValue = selectedCard.effectValue;


        //applyUpgrades.getUpgrade(selectedCardType, selectedCardValue);

        // try and actually apply upgrade
       switch (selectedCardType)
        {
            case CardEffect.HpIncrease:
                PermaPlayerStats.MaxHealthUpgrade(selectedCardValue);
                break;
            case CardEffect.ShieldIncrease:
                PermaPlayerStats.MaxShieldUpgrade(selectedCardValue);
                break;
            case CardEffect.ShieldRegenIncrease:
                PermaPlayerStats.ShieldRegenUpgrade(selectedCardValue);
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
            case CardEffect.DamageUpgrade:
                PermaPlayerStats.damageUpgrade(selectedCardValue);
                break;
            case CardEffect.SpecialUpgrade:
                PermaPlayerStats.spDmgUpgrade(selectedCardValue);
                break;
            case CardEffect.SPBulHP:
                PermaPlayerStats.spBulletHPUpgrade(selectedCardValue);
                break;
        }

        // change state back to playing
        GameManager.Instance.changeState(GameManager.GameState.NextArea);
    }

    // these two are self explanatory
    public void ShowCardSelection()
    { 
        cardSelectionUI.SetActive(true);
        //applyUpgrades.disableMove();
        move.enabled = false;
        shoot.enabled = false;
    }

    public void HideCardSelection()
    {
        cardSelectionUI.SetActive(false);
        //applyUpgrades.enableMove();
        move.enabled = true;
        shoot.enabled = true;
    }
}
