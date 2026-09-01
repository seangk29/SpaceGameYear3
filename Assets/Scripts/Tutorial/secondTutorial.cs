using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondTutorial : MonoBehaviour
{
    public GameObject startingTxt;
    public GameObject firstWaveTxt;
    public GameObject secondWaveTxt;
    public GameObject thirdTxt;
    public GameObject finalTxt;

    public GameObject enemies;

    public GameObject enemiesButHarder;

    public GameObject barrier;

    public GameObject returnHub;

    public int checkpointsNum;

    public GameObject[] checkpoints;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WavesStart());
    }

    // Update is called once per frame
    void Update()
    {
        switch (checkpointsNum)
        {
            case 1:
                checkpoints[0].SetActive(false);
                checkpoints[1].SetActive(true);
                break;
            case 2:
                checkpoints[1].SetActive(false);
                checkpoints[2].SetActive(true);
                break;
            case 3:
                checkpoints[2].SetActive(false);
                checkpoints[3].SetActive(true);
                break;
            case 4:
                checkpoints[3].SetActive(false);
                checkpoints[4].SetActive(true);
                break;
            case 5:
                checkpoints[4].SetActive(false);
                checkpoints[5].SetActive(true);
                break;
            case 6:
                checkpoints[5].SetActive(false);
                checkpoints[6].SetActive(true);
                break;
            case 7:
                checkpoints[6].SetActive(false);
                checkpoints[7].SetActive(true);
                break;
            case 8:
                checkpoints[7].SetActive(false);
                checkpoints[8].SetActive(true);
                break;
            case 9:
                checkpoints[8].SetActive(false);
                checkpoints[9].SetActive(true);
                break;
            case 10:
                checkpoints[9].SetActive(false);
                break;
        }


        if (checkpointsNum == 4)
        {
            firstWaveTxt.SetActive(false);
            enemies.SetActive(false);

            secondWaveTxt.SetActive(true);

            enemiesButHarder.SetActive(true);
        }


        if (checkpointsNum == 8)
        {
            secondWaveTxt.SetActive(false);
            enemiesButHarder.SetActive(false);

            thirdTxt.SetActive(true);
            barrier.SetActive(true);
        }

       if (checkpointsNum == 10)
        {
            barrier.SetActive(false);

            thirdTxt.SetActive(false);

            finalTxt.SetActive(true);

            returnHub.SetActive(true);
        }

    }

    IEnumerator WavesStart()
    {
        yield return new WaitForSecondsRealtime(5f);

        startingTxt.SetActive(false);

        yield return new WaitForSecondsRealtime(1f);

        firstWaveTxt.SetActive(true);


        checkpoints[0].SetActive(true);

        enemies.SetActive(true);
     

    }


}
