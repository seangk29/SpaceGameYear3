using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GlorgusShield : MonoBehaviour
{

    public bool canDamage;

    public int shieldHealth;

   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHealth <= 0)
        {

            canDamage = true;
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
