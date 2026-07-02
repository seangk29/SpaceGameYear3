using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;
using static Unity.Collections.AllocatorManager;

public class MidRunShop : MonoBehaviour
{

    public GameObject background;
    public GameObject notEnough;

    public shopRandomiser shopRandomiser;
    public PermaPlayerStats PermaPlayerStats;
    public PlayerData PlayerData;
    public RLPermData RLPermData;

    public int indic;

    public GameObject skippysUI;

    public UnlockHubItems unlock;

    public DialogueController controller;

    public TextMeshProUGUI conTxt;
    public TextMeshProUGUI upgTxt;
    public TextMeshProUGUI costTxt;

    private void Start()
    {
        RLPermData = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<RLPermData>();
        PlayerData = GameObject.Find("RLPermData").GetComponent<PlayerData>();
        PermaPlayerStats = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();
    }



    public void upgradeButton1()
    {
        background.SetActive(true);
        conTxt.text = shopRandomiser.randomizedCards[0].cardText;
        upgTxt.text = shopRandomiser.randomizedCards[0].descText;
        costTxt.text = shopRandomiser.randomizedCards[0].costs;
        indic = shopRandomiser.retainnumbers[0];

    }

    public void upgradeButton2()
    {
        background.SetActive(true);
        conTxt.text = shopRandomiser.randomizedCards[1].cardText;
        upgTxt.text = shopRandomiser.randomizedCards[1].descText;
        costTxt.text = shopRandomiser.randomizedCards[1].costs;
        indic = shopRandomiser.retainnumbers[1];
    }
    public void upgradeButton3()
    {
        background.SetActive(true);
        conTxt.text = shopRandomiser.randomizedCards[2].cardText;
        upgTxt.text = shopRandomiser.randomizedCards[2].descText;
        costTxt.text = shopRandomiser.randomizedCards[2].costs;
        indic = shopRandomiser.retainnumbers[2];
    }

    public void confirmUpgrade()
    {

        switch (indic)
        {
            case 1:
                if (PlayerData.score >= 200)
                {
                    PermaPlayerStats.spinUnlock();
                    PlayerData.score = PlayerData.score - 200;
                }
                else notEnough.SetActive(true);
                break;
            case 2:
                if (PlayerData.score >= 200)
                {
                    PermaPlayerStats.spreadUnlockUpgraded1(1);
                    PlayerData.score = PlayerData.score - 200;
                }
                else notEnough.SetActive(true);
                break;
            case 3:
                if (PlayerData.score >= 200)
                {
                    PermaPlayerStats.explodeUnlockUpgraded1(1);
                    PlayerData.score = PlayerData.score - 200;
                }
                else notEnough.SetActive(true);
                break;
            case 4:
                if (PlayerData.score >= 200)
                {
                    PermaPlayerStats.GunBot();
                    PlayerData.score = PlayerData.score - 200;
                }
                else notEnough.SetActive(true);
                break;
            case 5:
                if (PlayerData.score >= 200)
                {
                    PermaPlayerStats.ricochetUnlockUpgraded1(1); 
                    PlayerData.score = PlayerData.score - 200;
                }
                else notEnough.SetActive(true);
                break;
            case 6:
                if (PlayerData.score >= 200)
                {
                    PermaPlayerStats.explodeUnlockUpgraded1(1);
                    PlayerData.score = PlayerData.score - 200;
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

    public void exitShop()
    {
        skippysUI.SetActive(false);
        controller.activatorBool = false;
        unlock.skips.SetActive(true);
        unlock.paus.shooting.enabled = true;
    }

    public void notEnoughMoolaa()
    {
        notEnough.SetActive(false);
    }

}
