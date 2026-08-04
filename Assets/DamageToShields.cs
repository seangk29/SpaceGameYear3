using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToShields : MonoBehaviour
{

    

    public int shieldHealth;

    public GlorgusShield glorg;

    public float timer;
    public float timeToReturn;

    public bool bringBackGen;


    // Start is called before the first frame update
    void Start()
    {
       glorg = GameObject.FindGameObjectWithTag("glorgusShield").GetComponent<GlorgusShield>();
       
        
       
    }

    // Update is called once per frame
    void Update()
    {

        glorg = GameObject.FindGameObjectWithTag("glorgusShield").GetComponent<GlorgusShield>();

        if (shieldHealth <= 0)
        {
            glorg.shieldHealth = glorg.shieldHealth - 50;
            bringBackGen = true;
            this.gameObject.SetActive(false);

           
        }

        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        



        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "SpecialBullet")
        {
            shieldHealth = shieldHealth - 1;
        }


    }
}
