using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float speed;
    public float invul = 0;
    public float invulPeriod = 0;

    
    

    public int health = 3;



    int correctLayer;

    public bool SpRend;

    public AudioSource Daudio;

    public float fireDelay = 0.25f;
  //  float cooldownTimer = 0;


    private void Start()
    {
        
        correctLayer = gameObject.layer;

        if (gameObject.tag == "Player")
        {
            health = 3;
            
            PlayerSpawner.numLives = 3;

        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        
            health--;
            invul = 0.50f;
            gameObject.layer = 8;

        







            if (SpRend)
        {
            StartCoroutine(VisualIndicator(Color.red));
        }
       
        Daudio.Play();






        if (collider.gameObject.tag == "HealthPack")
        {
            health = health - 25;
            PlayerSpawner.numLives = PlayerSpawner.numLives + 1;

        }
    

}

  
    public void HealthUpgrade()
    {
        health = health + 1;
        Debug.Log("Choice");
        
    }


    private void Update()
    {

        //var rebound = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));


        if (invul <= 0)
        {
            gameObject.layer = correctLayer;

        }
        invul -= Time.deltaTime;
        
        if (health <= 0)
        {
            Die();
        }

    }

    private IEnumerator VisualIndicator (Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

   public void Die()
    {
        

       if (gameObject.tag == "Enemy")
        {
            EnemyWaveHandler.enemyCount = EnemyWaveHandler.enemyCount + 1;
            Debug.Log("Shot!");
            Debug.Log(EnemyWaveHandler.enemyCount);
        }

        Destroy(gameObject);

    }

 
}
