using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RunOverview : MonoBehaviour
{

    public int runInfo;

    public PermaPlayerStats tempData;
    public PlayerData playerData;
    public HUD hud;

    public TextMeshProUGUI[] runInfoText;

    public float start;
    public float start1;
    public float start2;
    public float start3;
    public float start4;
    public float start5;
    public float start6;
    public float start7;
    
    public bool[] counting;
    public bool transferScore;

    public int testScore;
    public int testScore1;

    public GameObject returnToHub;
    public Button toHub;

    public float overallScore;

    public bool dieHud;

    // Start is called before the first frame update
    void Start()
    {
        
        tempData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();

        playerData = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<PlayerData>();

        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

        dieHud = true;
      
    }

    // Update is called once per frame
    void Update()
    {
        switch (runInfo)
        {
            case 0:

                if (counting[0])
                {
                    start += 100;
                }

                runInfoText[0].text = "S.C.O.R.E. : " + start;

                if (start >= playerData.score)
                {
                    counting[0] = false;

                    runInfoText[0].text = "S.C.O.R.E. : " + playerData.score;

                    

                    runInfo += 1;
                }

                break;

            case 1:

                counting[1] = true;
                
                if (counting[1])
                {
                    start1 += 10;
                }

                runInfoText[1].text = "KILLS : " + start1;

                if (start1 >= playerData.kills)//playerData.score )
                {
                    counting[1] = false;

                    runInfoText[1].text = "KILLS : " + playerData.kills;

                    runInfo += 2;
                   
                }

                break;

            case 2:

                counting[2] = true;

                if (counting[2])
                {
                    start1 += 10;
                }

                runInfoText[2].text = "TIME : " + start2;

                if (start1 >= playerData.kills)//playerData.score )
                {
                    counting[2] = false;

                    runInfoText[2].text = "TIME : " + hud.time;

                    runInfo += 1;

                }

                break;


            case 3:

                counting[3] = true;

                if (counting[3])
                {
                    start3 += 1;
                }

                runInfoText[3].text = "HEALTH : " + start3;

                if (start3 >= tempData.health)//playerData.score )
                {
                    counting[3] = false;

                    runInfoText[3].text = "HEALTH : " + tempData.health;

                    runInfo += 1;

                }

                break;



            case 4:

                counting[4] = true;

                if (counting[4])
                {
                    start4 += 1;
                }

                runInfoText[4].text = "SHIELDS : " + start4;

                if (start4 >= tempData.shield)//playerData.score )
                {
                    counting[4] = false;

                    runInfoText[4].text = "SHIELDS : " + tempData.shield;

                    runInfo += 1;

                }

                break;


            case 5:

                counting[5] = true;

                if (counting[5])
                {
                    start5 += 1;
                }

                runInfoText[5].text = "SPECIAL BULLET HP : " + start5;

                if (start5 >= tempData.spBulletHealth)
                {
                    counting[5] = false;

                    runInfoText[5].text = "SPECIAL BULLET HP : " + tempData.spBulletHealth;

                    runInfo += 1;

                }

                break;



            case 6:

                counting[6] = true;

                if (counting[6])
                {
                    start6 += 1;
                }

                runInfoText[6].text = "SPEED : " + start6;

                if (start6 >= tempData.speed)
                {
                    counting[6] = false;

                    runInfoText[6].text = "SPEED : " + tempData.speed;

                    runInfo += 1;

                }

                break;

            case 7:

                counting[7] = true;

                if (counting[7])
                {
                    start7 += 100;
                }

                runInfoText[7].text = "OVERALL SCORE : " + start7;

                if (start7 >= overallScore)
                {
                    counting[7] = false;

                   overallScore =  playerData.score + tempData.speed * 100 + playerData.kills * 10 + tempData.health * 100 + tempData.shield * 100 + tempData.spBulletHealth * 100;

                    runInfoText[7].text = "OVERALL SCORE : " + overallScore;

                    transferScore = true;

                    returnToHub.SetActive(true);
                   // toHub.Select();

                    runInfo += 1;

                }

                


                break;

                case 8:

                if (transferScore)
                {
                    playerData.score = overallScore;
                    transferScore = false;
                }

                break;
        }
    }
}
