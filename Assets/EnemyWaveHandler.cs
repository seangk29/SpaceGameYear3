using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveHandler : MonoBehaviour
{
    public GameObject enemyWave1prefab;
    public GameObject enemyWave2prefab;
    public GameObject enemyWave3prefab;

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

        if (enemyCount == 41)
        {
            Instantiate(enemyWave1prefab);
            enemyCount = enemyCount + 1;
        }
    }
}
