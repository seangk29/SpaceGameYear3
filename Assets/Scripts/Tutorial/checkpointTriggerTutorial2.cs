using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointTriggerTutorial2 : MonoBehaviour
{
    public secondTutorial secondTutorial;

    private void Start()
    {

        if (secondTutorial == null)
        {
            secondTutorial = GameObject.FindGameObjectWithTag("tutorialManager").GetComponent<secondTutorial>();
        }
        else
            return;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("checkpoint"))
        {
            secondTutorial.checkpointsNum++;
        }
    }
}
