using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTimer : MonoBehaviour
{
   public GameObject StarsBg;

    public float BgTimer = 0;

    // Update is called once per frame

    private void Start()
    {
        Instantiate(StarsBg);
    }
    void Update()
    {
        BgTimer += Time.deltaTime;

        if (BgTimer >= 10)
        {
            BgTimer = 0;
            Instantiate(StarsBg);
            
        }
    }
}
