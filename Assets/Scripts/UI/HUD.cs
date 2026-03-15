using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public ActivePlayerHealth activePlayer;
    public PlayerData playerData;

    public TextMeshProUGUI killsTMP;
    public TextMeshProUGUI timerTMP;

    public Image[] health;
    public Image[] shield;

    public float time;
    private int minutes;
    private int seconds;
    private float miliseconds;


    private void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
    }

    private void Update()
    {
        if (activePlayer == null)
        {
            activePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ActivePlayerHealth>();
        }
        if (playerData == null)
        {
            playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
        }

        HPBarUpdate();
        ShieldBarUpdate();
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

    public void KillsUpdate()
    {
        killsTMP.text = "K.I.L.L.S.: " + playerData.kills;
    }

    public void TimerUpdate()
    {
        /*time += Time.deltaTime;
        timerTMP.text = "T.I.M.E.: " + Mathf.Floor(time).ToString();*/

        time += Time.deltaTime;
        minutes = Mathf.FloorToInt(time / 60f);
        seconds = Mathf.FloorToInt(time - minutes * 60);
        miliseconds = (time - seconds) * 100;

        timerTMP.text = string.Format("T.I.M.E.: {0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
    }

}
