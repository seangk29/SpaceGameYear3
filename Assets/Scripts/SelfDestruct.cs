using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timer = 1f;

    public EnemyWaveHandler Wave;

    public bool selfDestruct = true;


    private void Start()
    {
        Wave = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyWaveHandler>(); 
    }
    // Update is called once per frame
    void Update()
    {
        if (selfDestruct)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Destroy(gameObject);

                if (gameObject.tag == "Enemy")
                {
                    Wave.enemyCount = Wave.enemyCount + 1;

                    Debug.Log(Wave.enemyCount);
                }
            }
        }
        
    }
}
