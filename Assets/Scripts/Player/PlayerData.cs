using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public PermaPlayerStats playerStats;
    public string activeSpecial;

    public GameObject spreadShot;
    public GameObject ricochetShot;
    public GameObject explodeShot;

    public PlayerShooting currentSpecialPos1;
    public PlayerShooting currentSpecialPos2;
    public PlayerShooting currentSpecialPos3;
    public PlayerShooting currentSpecialPos4;

    public int score = 0;


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
                case "Ricochet":
                    GetRichochetShot();
                    break;
                case "Explode":
                    GetExplodeShot();
                    break;
            }
        }
    }

    public void GetSpreadShot()
    {
        currentSpecialPos1.SbulletPrefab = spreadShot;
        currentSpecialPos2.SbulletPrefab = spreadShot;
        currentSpecialPos3.SbulletPrefab = spreadShot;
        currentSpecialPos4.SbulletPrefab = spreadShot;

        currentSpecialPos1.SPfireDelay = 1.5f;
        currentSpecialPos2.SPfireDelay = 1.5f;
        currentSpecialPos3.SPfireDelay = 1.5f;
        currentSpecialPos4.SPfireDelay = 1.5f;
        activeSpecial = "Spread";
    }

    public void GetRichochetShot()
    {
        currentSpecialPos1.SbulletPrefab = ricochetShot;
        currentSpecialPos2.SbulletPrefab = ricochetShot;
        currentSpecialPos3.SbulletPrefab = ricochetShot;
        currentSpecialPos4.SbulletPrefab = ricochetShot;

        currentSpecialPos1.SPfireDelay = 1f;
        currentSpecialPos2.SPfireDelay = 1f;
        currentSpecialPos3.SPfireDelay = 1f;
        currentSpecialPos4.SPfireDelay = 1f;
        activeSpecial = "Ricochet";

    }

    public void GetExplodeShot()
    {
        currentSpecialPos1.SbulletPrefab = explodeShot;
        currentSpecialPos2.SbulletPrefab = explodeShot;
        currentSpecialPos3.SbulletPrefab = explodeShot;
        currentSpecialPos4.SbulletPrefab = explodeShot;

        currentSpecialPos1.SPfireDelay = 1f;
        currentSpecialPos2.SPfireDelay = 1f;
        currentSpecialPos3.SPfireDelay = 1f;
        currentSpecialPos4.SPfireDelay = 1f;
        activeSpecial = "Explode";

    }


}
