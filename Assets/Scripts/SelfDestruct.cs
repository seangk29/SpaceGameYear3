using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timer = 1f;
    
    
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);

            if (gameObject.tag == "Enemy")
            {
                EnemyWaveHandler.enemyCount = EnemyWaveHandler.enemyCount + 1;
              
                Debug.Log(EnemyWaveHandler.enemyCount);
            }
        }
    }
}
