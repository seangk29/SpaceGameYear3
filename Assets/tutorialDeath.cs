using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialDeath : MonoBehaviour
{
    public int health;
    public firstTutorial tutorial;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            health--;
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            tutorial.enemiesDeaths++;
        Destroy(gameObject);
        }
    }


}
