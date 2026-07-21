using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGlorgus : MonoBehaviour
{

    public BossHealth health;

    public int phase1complete;
    public int phase2complete;
    public int phase3complete;

    public GlorgusShield glorg;
    public GameObject glorgShield;
    public float Atimer;
    public float timeToShield;
    
    public float Btimer;
    public float timeToAttack;
    public bool glorgusAttack;

    public GameObject attack0;
    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;
    public GameObject attack4;
    public GameObject attack5;
    public GameObject attack6;


    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<BossHealth>();
        glorg = GameObject.FindGameObjectWithTag("glorgusShield").GetComponent<GlorgusShield>();
    }

    // Update is called once per frame
    void Update()
    {


        if (glorg.canDamage)
        {

            glorgusAttack = false;
         
            Atimer += Time.deltaTime;

            if (Atimer >= timeToShield)
            {
                glorg.canDamage = false;
                Atimer = 0;
                glorgShield.SetActive(true);
                glorgusAttack = true;
                glorg.shieldHealth = 100;
            }

        }



        if (glorgusAttack)
        {
            Btimer += Time.deltaTime;

            if (Btimer >= timeToAttack)
            {
                int rand = Random.Range(0, 6);

                switch (rand)
                {
                    case 0:
                        Instantiate(attack0, transform.position, transform.rotation);
                        Btimer = 0;
                        break;
                    case 1:
                        Instantiate(attack1, transform.position, transform.rotation);
                        Btimer = 0;
                        break;
                    case 2:
                        Instantiate(attack2, transform.position, transform.rotation);
                        Btimer = 0;
                        break;
                    case 3:
                        Instantiate(attack3, transform.position, transform.rotation);
                        Btimer = 0;
                        break;
                    case 4:
                        Instantiate(attack4, transform.position, transform.rotation);
                        Btimer = 0;
                        break;
                    case 5:
                        Instantiate(attack5, transform.position, transform.rotation);
                        Btimer = 0;
                        break;
                    case 6:
                        Instantiate(attack6, transform.position, transform.rotation);
                        Btimer = 0;
                        break;

                }
            }





            /* if (health.health <=  phase1complete)
             {
                 Vector3 pos = transform.position;

                 pos = new Vector3(-8, 0.5f, 0);

                 transform.position = pos;

                 Quaternion rot = transform.rotation;

                 rot = Quaternion.Euler(0, 0, -90);

                 transform.rotation = rot;


             }

             if (health.health <= phase2complete)
             {
                 Vector3 pos = transform.position;

                 pos = new Vector3(8, 0.5f, 0);

                 transform.position = pos;

                 Quaternion rot = transform.rotation;

                 rot = Quaternion.Euler(0, 0, 90);

                 transform.rotation = rot;


             }

             if (health.health <= phase3complete)
             {
                 Vector3 pos = transform.position;

                 pos = new Vector3(0, 2.5f, 0);

                 transform.position = pos;

                 Quaternion rot = transform.rotation;

                 rot = Quaternion.Euler(0, 0, 180);

                 transform.rotation = rot;


             }*/




        }

    }

}


