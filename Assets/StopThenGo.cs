using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopThenGo : MonoBehaviour
{

    public float timer;
    public float timeToGo;

    public MoveForward move;
    
    
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<MoveForward>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToGo )
        {
            move.enabled = true;
            
        }
    }
}
