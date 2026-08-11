using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointTrigger : MonoBehaviour
{
    public firstTutorial firstTutorial;

    private void Start()
    {
        if (firstTutorial == null)
        {
            firstTutorial = GameObject.FindGameObjectWithTag("tutorialManager").GetComponent<firstTutorial>();
        }
        else
            return;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("checkpoint"))
        {
            firstTutorial.checkpointsNum++;
        }
    }
}
