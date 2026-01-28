using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject Boss;
    public int BossCount = 1;
    public float timer = 0;
    public float timeToSpawn;
    public int nowSpawn;

    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        if (BossCount == nowSpawn)
        {

            timer += Time.deltaTime;
            
            if (timer >= timeToSpawn)
            {
                Instantiate(Boss);
                BossCount = BossCount + 1;
               
            }


            
          
        }

    }


}
