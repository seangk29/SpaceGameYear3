using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAudio : MonoBehaviour
{
    public AudioSource shoot;

    public float timer;
    public float shootTimer;

    public int enemyCount;
    public int maxEnemyCount;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        shoot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootTimer)

        {
            shoot.Play();
            timer = 0;

        }
        

        if (enemyCount == maxEnemyCount)
        {
            Destroy(gameObject);
        }
    }
}
