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

    public TextMeshProUGUI killsTMP;
    public TextMeshProUGUI timerTMP;
   

    public Image[] health;
    public Image[] shield;
    public Image[] live;

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

        HPBarUpdate();
        ShieldBarUpdate();
        LivesUpdate();
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
