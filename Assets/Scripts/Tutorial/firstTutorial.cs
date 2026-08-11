using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstTutorial : MonoBehaviour
{
    public GameObject startingTxt;
    public GameObject movementTxt;
    public GameObject helpTxt;

    public GameObject firstShootingTxt;

    public int checkpointsNum;

    public GameObject[] checkpoints;

    public GameObject enemies;

    private void Start()
    {
        StartCoroutine(CheckpointsStart());
    }


    private void Update()
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
                break;
        }

    if (checkpointsNum == 4)
        {
            movementTxt.SetActive(false);
            helpTxt.SetActive(false);

            firstShootingTxt.SetActive(true);
            enemies.SetActive(true);
        }


    }

    IEnumerator CheckpointsStart()
    {
        yield return new WaitForSecondsRealtime(5f);

        startingTxt.SetActive(false);
        movementTxt.SetActive(true);
        helpTxt.SetActive(true);

        checkpoints[0].SetActive(true);

    }




}
