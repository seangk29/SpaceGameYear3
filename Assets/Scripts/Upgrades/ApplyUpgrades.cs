using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// i still cant get it to not overflow ram im losing my mind doing this

public class ApplyUpgrades : MonoBehaviour
{

    public static PermaPlayerStats PermaPlayerStats;
    public static PlayerMovement move;
    public static PlayerShooting shoot;
    public static CardManager cardManager;

    // Start is called before the first frame update
    void Start()
    {
        PermaPlayerStats = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();
        cardManager = GetComponent<CardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot == null)
        {
            shoot = GameObject.FindGameObjectWithTag("GunPos").GetComponent<PlayerShooting>();
        }

        if (move == null)
        {
            move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }

    }

    public void getUpgrade(CardEffect selectedCardType, int selectedCardValue)
    {
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
        }
    }

    public void disableMove()
    {
        move.enabled = false;
        shoot.enabled = false;
    }

    public void enableMove()
    {
        move.enabled = true;
        shoot.enabled = true;
    }
}
