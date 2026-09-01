using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeathTutorial : MonoBehaviour
{
    public ActivePlayerHealth health;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tutorialDeath" && health.dodging == false)
        {
            //Destroy(gameObject);

            health.health = 0;
        }
    }
}
