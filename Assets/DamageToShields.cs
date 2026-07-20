using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToShields : MonoBehaviour
{

    

    public int shieldHealth;

    public GlorgusShield glorg;


    // Start is called before the first frame update
    void Start()
    {
        glorg = GameObject.FindGameObjectWithTag("glorgusShield").GetComponent<GlorgusShield>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHealth <= 0)
        {
            glorg.shieldHealth = shieldHealth / 2;
            shieldHealth = 100;
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
