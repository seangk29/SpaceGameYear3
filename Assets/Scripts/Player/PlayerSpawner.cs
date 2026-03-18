using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject deathScreen;
    GameObject playerInstance;
    public PlayerData playerData;
   

    float respawnTimer;

    [SerializeField]public int numLives = 1;
    public int lastLife = 4;

   
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        numLives--;
       
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Time.timeScale = 1f;
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
        if (playerInstance == null && numLives == 0)
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
            playerData.spaceMoney = playerData.score;
            playerData.score = 0;

        }
      
    }


   
}
