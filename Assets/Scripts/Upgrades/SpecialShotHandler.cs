using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialShotHandler : MonoBehaviour
{
    public PermaPlayerStats playerStats;
    public bool spreadUnlocked;
    public CardExtras extras;
   
    public string activeSpecial;

    public GameObject spreadShot;
    public GameObject spreadShotUpgraded1;
    public GameObject ricochetShot;
    public GameObject ricochetShotUpgraded1;
    public GameObject explodeShot;
    public GameObject explodeShotUpgraded1;
    public GameObject spinShot;
    public GameObject gunBot;

  

    public PlayerShooting currentSpecialPos1;
    public PlayerShooting currentSpecialPos2;
    public PlayerShooting currentSpecialPos3;
    public PlayerShooting currentSpecialPos4;

    private void Start()
    {
        
       
        
        PlayerShooting currentSpecial = GetComponent<PlayerShooting>();

        playerStats = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();

        if (playerStats.canUseSpecial)
        {
            Debug.Log("aaaaaa");
            activeSpecial = playerStats.activeSpecial;

            switch (activeSpecial)
            {

                case "Spread":
                    GetSpreadShot();
                    break;
                case "SpreadUpgraded1":
                    GetSpreadShotUpgraded1();
                    break;
                case "Ricochet":
                    GetRicochetShot();
                    break;
                case "RicochetUpgraded1":
                    GetRicochetShotUpgraded1();
                    break;
                case "Explode":
                    GetExplodeShot();
                    break;
                case "ExplodeUpgraded1":
                    GetExplodeShotUpgraded1();
                    break;
                case "Spin":
                    getSpinShot();
                    break;
            }
        }
    }


    private void Update()
    {
        if (playerStats.activeSpin == true)
        {
            spinShot.SetActive(true);
        }

        if (playerStats.activeGunBot == true)
        {
            gunBot.SetActive(true);
        }
    }
    public void GetSpreadShot()
    {
        currentSpecialPos1.SbulletPrefab = spreadShot;
        

        currentSpecialPos1.SPfireDelay = 0.5f;
        
        activeSpecial = "Spread";
        spreadUnlocked = true;
                            
    }

    public void GetSpreadShotUpgraded1()
    {
        currentSpecialPos1.SbulletPrefab = spreadShotUpgraded1;

        currentSpecialPos1.SPfireDelay = 0.5f;
        
        activeSpecial = "SpreadUpgraded1";
        spreadUnlocked = true;

    }

    public void GetRicochetShot()
    {
        currentSpecialPos1.SbulletPrefab = ricochetShot;
        
        currentSpecialPos1.SPfireDelay = 1f;
       
        activeSpecial = "Ricochet";

    }

    public void GetRicochetShotUpgraded1()
    {
        currentSpecialPos1.SbulletPrefab = ricochetShotUpgraded1;

        currentSpecialPos1.SPfireDelay = 1f;

        activeSpecial = "RicochetUpgraded1";

    }

    public void GetExplodeShot()
    {
        currentSpecialPos1.SbulletPrefab = explodeShot;
        

        currentSpecialPos1.SPfireDelay = 1f;
        
        activeSpecial = "Explode";

    }


    public void GetExplodeShotUpgraded1()
    {
        currentSpecialPos1.SbulletPrefab = explodeShotUpgraded1;


        currentSpecialPos1.SPfireDelay = 1f;

        activeSpecial = "ExplodeUpgraded1";

    }

    public void getSpinShot()
    {
        spinShot.SetActive(true);
      
    }

    public void getGunBot()
    {
        gunBot.SetActive(true);
     
    }
}
