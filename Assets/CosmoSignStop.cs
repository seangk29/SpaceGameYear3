using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmoSignStop : MonoBehaviour
{
    public float timer = 0;
    public float timeToStop;

    MoveForward move;

    private void Start()
    {
        move = GetComponent<MoveForward>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToStop)
        {
            move.movingForward = false;
        }
    }
}
