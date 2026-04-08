using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopButtons : MonoBehaviour
{
    public GameObject background;
    public TextMeshProUGUI conTxt;
    public TextMeshProUGUI upgTxt;

    public ShopText[] shopText;
    public int indic;

    public PermaPlayerStats PermaPlayerStats;
    public PlayerData PlayerData;

    public GameObject skippysUI;

    public GameObject notEnough;

    public UnlockHubItems unlock;

    public DialogueController controller;

    

    private void Start()
    {
        PermaPlayerStats = GameObject.Find("PlayerData").GetComponent<PermaPlayerStats>();
        PlayerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
    }


    public void healthUpgrade()
    {
       background.SetActive(true);
        conTxt.text = shopText[0].conTxt;
        upgTxt.text = shopText[0].upgradeTxt;
        indic = 1;
    }

    public void shieldUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[1].conTxt;
        upgTxt.text = shopText[1].upgradeTxt;
        indic = 2;
    }

    public void shieldCooldown()
    {
        background.SetActive(true);
        conTxt.text = shopText[2].conTxt;
        upgTxt.text = shopText[2].upgradeTxt;
        indic = 3;
    }

    public void bulletUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[3].conTxt;
        upgTxt.text = shopText[3].upgradeTxt;
        indic = 4;
    }

    public void speedUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[4].conTxt;
        upgTxt.text = shopText[4].upgradeTxt;
        indic = 5;
    }

    public void spBulletHpUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[5].conTxt;
        upgTxt.text = shopText[5].upgradeTxt;
        indic = 6;
    }

    public void spBulletCooldownUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[6].conTxt;
        upgTxt.text = shopText[6].upgradeTxt;
        indic = 7;
    }

    public void lifeUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[7].conTxt;
        upgTxt.text = shopText[7].upgradeTxt;
        indic = 8;
    }

    public void exitShop()
    {
        skippysUI.SetActive(false);
        controller.skipBool = false;
        unlock.skips.SetActive(true);
        unlock.paus.shooting.enabled = true;
    }

    public void notEnoughMoolaa()
    {
        notEnough.SetActive(false);
    }


    public void confirmUpgrade()
    {

        switch(indic)
        {
            case 1:
                if (PlayerData.spaceMoney >= 200)
                {
                    PermaPlayerStats.maxHealth++;
                    PermaPlayerStats.health++;
                    PlayerData.spaceMoney = PlayerData.spaceMoney - 200;
                }
                else notEnough.SetActive(true);
            break;
            case 2:
                PermaPlayerStats.maxShield++;
                PermaPlayerStats.shield++;
                break;
            case 3:
                PermaPlayerStats.regenShieldTimer++;
                break;
            case 4:
                PermaPlayerStats.damage++;
                break;
            case 5:
                PermaPlayerStats.maxSpeed++;
                PermaPlayerStats.speed++;
                break;
            case 6:
                PermaPlayerStats.spBulletHealth++;

                break;
            case 7:
                PermaPlayerStats.maxSpeed++;
                PermaPlayerStats.speed++;
                break;
            case 8:
                PermaPlayerStats.maxSpeed++;
                PermaPlayerStats.speed++;
                break;


        }


        background.SetActive(false);
    }

    public void denyUpgrades()
    {
        background.SetActive(false);
    }

}

