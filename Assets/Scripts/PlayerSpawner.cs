using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;

    float respawnTimer;

    public static int numLives = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        //SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        numLives--;
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInstance == null && numLives > 0)
        {
        
           
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
            
        }
    }


   
}
