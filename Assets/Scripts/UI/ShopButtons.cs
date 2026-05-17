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
    public TextMeshProUGUI costTxt;

    public ShopText[] shopText;
    public int indic;

    public PermaPlayerStats PermaPlayerStats;
    public PlayerData PlayerData;
    public RLPermData RLPermData;

    public GameObject skippysUI;

    public GameObject notEnough;

    public UnlockHubItems unlock;

    public DialogueController controller;

    

    private void Start()
    {
        //PermaPlayerStats = GameObject.Find("PlayerData").GetComponent<PermaPlayerStats>();
        RLPermData = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<RLPermData>();
        PlayerData = GameObject.Find("RLPermData").GetComponent<PlayerData>();
    }


    public void healthUpgrade()
    {
       background.SetActive(true);
        conTxt.text = shopText[0].conTxt;
        upgTxt.text = shopText[0].upgradeTxt;
        costTxt.text = shopText[0].cost;
        indic = 1;
    }

    public void shieldUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[1].conTxt;
        upgTxt.text = shopText[1].upgradeTxt;
        costTxt.text = shopText[1].cost;
        indic = 2;
    }

    public void shieldCooldown()
    {
        background.SetActive(true);
        conTxt.text = shopText[2].conTxt;
        upgTxt.text = shopText[2].upgradeTxt;
        costTxt.text = shopText[2].cost;
        indic = 3;
    }

    public void bulletUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[3].conTxt;
        upgTxt.text = shopText[3].upgradeTxt;
        costTxt.text = shopText[3].cost;
        indic = 4;
    }

    public void speedUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[4].conTxt;
        upgTxt.text = shopText[4].upgradeTxt;
        costTxt.text = shopText[4].cost;
        indic = 5;
    }

    public void spBulletHpUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[5].conTxt;
        upgTxt.text = shopText[5].upgradeTxt;
        costTxt.text = shopText[5].cost;
        indic = 6;
    }

    public void spBulletCooldownUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[6].conTxt;
        upgTxt.text = shopText[6].upgradeTxt;
        costTxt.text = shopText[6].cost;
        indic = 7;
    }

    public void lifeUpgrade()
    {
        background.SetActive(true);
        conTxt.text = shopText[7].conTxt;
        upgTxt.text = shopText[7].upgradeTxt;
        costTxt.text = shopText[7].cost;
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
                if (PlayerData.spaceMoney >= 20000)
                {
                    RLPermData.maxHealth++;
                    RLPermData.health++;
                    PlayerData.spaceMoney = PlayerData.spaceMoney - 20000;
                 }
                else notEnough.SetActive(true);
            break;
            case 2:
                if (PlayerData.spaceMoney >= 25000)
                {
                    RLPermData.maxShield++;
                    RLPermData.shield++;
                    PlayerData.spaceMoney = PlayerData.spaceMoney - 25000;
                } 
                else notEnough.SetActive(true);
                break;
            case 3:
                if (PlayerData.spaceMoney >= 15000)
                {
                    RLPermData.regenShieldTimer++;
                    PlayerData.spaceMoney = PlayerData.spaceMoney - 15000;
                }
                else notEnough.SetActive(true);
                break;
            case 4:
                if (PlayerData.spaceMoney >= 50000)
                {
                    RLPermData.damage++;
                    PlayerData.spaceMoney = PlayerData.spaceMoney - 50000;
                }
                else notEnough.SetActive(true);
                break;
            case 5:
                if (PlayerData.spaceMoney >= 15000)
                {
                    RLPermData.maxSpeed++;
                    RLPermData.speed++;
                    PlayerData.spaceMoney = PlayerData.spaceMoney - 15000;
                }
                else notEnough.SetActive(true);
                break;
            case 6:
                if (PlayerData.spaceMoney >= 40000)
                {
                    RLPermData.spBulletHealth++;
                    PlayerData.spaceMoney = PlayerData.spaceMoney - 40000;
                }
                else notEnough.SetActive(true);
                break;
            case 7:
                if (PlayerData.spaceMoney >= 200)
                {
                    RLPermData.maxSpeed++;
                    RLPermData.speed++;
                    PlayerData.spaceMoney = PlayerData.spaceMoney - 200;
                }
                else notEnough.SetActive(true);
                break;
            case 8:
                if (PlayerData.spaceMoney >= 200)
                {
                    RLPermData.maxSpeed++;
                    RLPermData.speed++;
                    PlayerData.spaceMoney = PlayerData.spaceMoney - 200;
                }
                else notEnough.SetActive(true);
                break;


        }


        background.SetActive(false);
    }

    public void denyUpgrades()
    {
        background.SetActive(false);
    }

}

