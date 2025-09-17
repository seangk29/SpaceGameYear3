using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public float invul = 0;
    public float invulPeriod = 0;

    

    public int health;
  

    int correctLayer;

    public bool SpRend;

    public AudioSource Daudio;


    private void Start()
    {
        correctLayer = gameObject.layer;
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
        
     

      
    }

    private void Update()
    {
        
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

    void Die()
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
