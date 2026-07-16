using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public ActivePlayerHealth activePlayer;
    public PlayerData playerData;
    public PlayerSpawner spawn;
    public PlayerShooting shooting;
    public PermaPlayerStats shotHandler;

    public TextMeshProUGUI killsTMP;
    public TextMeshProUGUI timerTMP;
   

    public Image[] health;
    public Image[] shield;
    public Image[] live;
    public Image[] ammo;

    public Image[] specialShotImage;

    public int indic;

    public float time;
    private int minutes;
    private int seconds;
    private float miliseconds;


    private void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<PlayerData>();
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<PlayerSpawner>();
       
    }

    private void Update()
    {
        if (activePlayer == null)
        {
            activePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ActivePlayerHealth>();
        }
        if (playerData == null)
        {
            playerData = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<PlayerData>();
        }

        if (spawn == null)
        {
            spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<PlayerSpawner>();
        }

        if (shooting == null)
        {
            shooting = GameObject.FindGameObjectWithTag("GunPos").GetComponent<PlayerShooting>();
        }

        if (shotHandler == null)
        {
            shotHandler = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();
        }

       indic = shotHandler.specialIndic;

        HPBarUpdate();
        ShieldBarUpdate();
        LivesUpdate();
        AmmoUpdate();
        KillsUpdate();
        TimerUpdate();


    }

    public void HPBarUpdate()
    {
        for (int i = 0; i < health.Length; i++)
        {
            if (i < activePlayer.health)
            {
                health[i].enabled = true;
            }
            else
            {
                health[i].enabled = false;
            }
        }
    }

    public void ShieldBarUpdate()
    {
        for (int i = 0; i < shield.Length; i++)
        {
            if (i < activePlayer.shieldHealth)
            {
                shield[i].enabled = true;
            }
            else
            {
                shield[i].enabled = false;
            }
        }
    }

    public void LivesUpdate()
    {
        for (int i = 0; i < live.Length; i++)
        {
            if (i < spawn.numLives)
            {
                live[i].enabled = true;
            }
            else
            {
                live[i].enabled = false;
            }
        }
    }

    public void AmmoUpdate()
    {
        for (int i = 0; i < ammo.Length; i++)
        {
            if (i < shooting.specialAmmo)
            {
                ammo[i].enabled = true;
            }
            else
            {
                ammo[i].enabled = false;
            }
        }


        switch (indic)
        {
            case 1:
               // specialShotImage[0].enabled = true;
               // specialShotImage[1].enabled = false;
               // specialShotImage[2].enabled = false;

                ammo[0].color = new Color(1f,0.6470588f, 0f, 1f);
                ammo[1].color = new Color(1f, 0.6470588f, 0f, 1f); 
                ammo[2].color = new Color(1f, 0.6470588f, 0f, 1f);
                ammo[3].color = new Color(1f, 0.6470588f, 0f, 1f);
                ammo[4].color = new Color(1f, 0.6470588f, 0f, 1f);

                break;
            case 2:
               // specialShotImage[0].enabled = true;
                //specialShotImage[1].enabled = false;
                //specialShotImage[2].enabled = false;

                ammo[0].color = new Color(1f,0.6470588f, 0f, 1f);
                ammo[1].color = new Color(1f, 0.6470588f, 0f, 1f); 
                ammo[2].color = new Color(1f, 0.6470588f, 0f, 1f);
                ammo[3].color = new Color(1f, 0.6470588f, 0f, 1f);
                ammo[4].color = new Color(1f, 0.6470588f, 0f, 1f);


                break;
            case 3:
                //specialShotImage[1].enabled = true;
                //specialShotImage[0].enabled = false;
              //  specialShotImage[2].enabled = false;

                ammo[0].color = Color.yellow;
                ammo[1].color = Color.yellow;
                ammo[2].color = Color.yellow;
                ammo[3].color = Color.yellow;
                ammo[4].color = Color.yellow;


                break;
            case 4:
               //specialShotImage[1].enabled = true;
               // specialShotImage[0].enabled = false;
               // specialShotImage[2].enabled = false;

                ammo[0].color = Color.yellow;
                ammo[1].color = Color.yellow;
                ammo[2].color = Color.yellow;
                ammo[3].color = Color.yellow;
                ammo[4].color = Color.yellow;


                break;
            case 5:
                //specialShotImage[2].enabled = true;
                //specialShotImage[0].enabled = false;
               // specialShotImage[1].enabled = false;

                ammo[0].color = Color.blue;
                ammo[1].color = Color.blue;
                ammo[2].color = Color.blue;
                ammo[3].color = Color.blue;
                ammo[4].color = Color.blue;

                break;
            case 6:
                //specialShotImage[2].enabled = true;
               // specialShotImage[0].enabled = false;
                //specialShotImage[1].enabled = false;

                ammo[0].color = Color.blue;
                ammo[1].color = Color.blue;
                ammo[2].color = Color.blue;
                ammo[3].color = Color.blue;
                ammo[4].color = Color.blue;

                break;
        }


    }

    public void KillsUpdate()
    {
        killsTMP.text = "KILLS: " + playerData.kills;
    }

    public void TimerUpdate()
    {
        /*time += Time.deltaTime;
        timerTMP.text = "T.I.M.E.: " + Mathf.Floor(time).ToString();*/

        time += Time.deltaTime;
        minutes = Mathf.FloorToInt(time / 60f);
        seconds = Mathf.FloorToInt(time - minutes * 60);
        miliseconds = (time - seconds) * 100;

        timerTMP.text = string.Format("TIME: {0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
    }

}
