using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveHandler : MonoBehaviour
{
    public GameObject enemyWave1prefab;
    public GameObject enemyWave2prefab;
    public GameObject enemyWave3prefab;


    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject Choice3;
    public GameObject Choice4;
    public GameObject Choice5;


    public GameObject player;

    public static int enemyCount;



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyWave1prefab);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == 23)
        {
            Instantiate(enemyWave2prefab);
            enemyCount = enemyCount + 1;
        }

        if (enemyCount == 30)
        {
            Instantiate(enemyWave3prefab);
            enemyCount = enemyCount + 1;
        }
        
        if (enemyCount == 56)
        {
            int randChoice = Random.Range(1, 6);

            switch (randChoice)
            {
                case 1:
                    Instantiate(Choice1);
                    enemyCount = enemyCount + 1;
                    PlayerShooting.MakingChoice = true;
                    PlayerSpawner.numLives = PlayerSpawner.numLives + 1;
                    Debug.Log("Choice1!!!");
                    enemyCount = 0;
                    return;
                case 2:
                    Instantiate(Choice2);
                    enemyCount = enemyCount + 1;
                    PlayerShooting.MakingChoice = true;
                    PlayerSpawner.numLives = PlayerSpawner.numLives + 1;
                    Debug.Log("Choice2!!!");
                    enemyCount = 0;
                    return;
                case 3:
                    Instantiate(Choice3);
                    enemyCount = enemyCount + 1;
                    PlayerShooting.MakingChoice = true;
                    PlayerSpawner.numLives = PlayerSpawner.numLives + 1;
                    Debug.Log("Choice3!!!");
                    enemyCount = 0;
                    return;
                case 4:
                    Instantiate(Choice4);
                    enemyCount = enemyCount + 1;
                    PlayerShooting.MakingChoice = true;
                    PlayerSpawner.numLives = PlayerSpawner.numLives + 1;
                    Debug.Log("Choice4!!!");
                    enemyCount = 0;
                    return;
                case 5:
                    Instantiate(Choice5);
                    enemyCount = enemyCount + 1;
                    PlayerShooting.MakingChoice = true;
                    PlayerSpawner.numLives = PlayerSpawner.numLives + 1;
                    Debug.Log("Choice5!!!");
                    enemyCount = 0;
                    return;
            }

           

            
           
        }


    }
}
