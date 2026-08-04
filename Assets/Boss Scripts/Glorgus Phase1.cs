using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlorgusPhase1 : MonoBehaviour
{

    public BossHealth health;
    public MoveForward move;
    public FacesPlayer face;
    public DamageToShields damage1;
    public DamageToShields damage2;
    public DamageToShields damage3;
    public DamageToShields damage4;
    public GlorgusPhase2 phase2;

    public int phase1complete;
  
    public GlorgusShield glorg;
    public GameObject glorgShield;
    public GameObject gen1;
    public GameObject gen2;
    public float Atimer;
    public float timeToShield;

    public float Btimer;
    public float timeToAttack;
    public bool glorgusAttack;

    public float genTimer;
    public float genBack;

    public GameObject attack0;
    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;
    public GameObject attack4;
    public GameObject attack5;
    public GameObject attack6;





    void Start()
    {
        health = GetComponent<BossHealth>();
        glorg = GameObject.FindGameObjectWithTag("glorgusShield").GetComponent<GlorgusShield>();
        move = GetComponent<MoveForward>();
        face = GetComponent<FacesPlayer>();
        phase2 = GetComponent<GlorgusPhase2>();
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

        }


        if (health.health <= phase1complete)
        {
            phase2.enabled = true;
        }

        if (damage1.bringBackGen)
        {
            genTimer += Time.deltaTime;
            
            if (genTimer >= genBack)
            {
                gen1.SetActive(true);
                damage1.shieldHealth = 25;
                damage1.bringBackGen = false;
                genTimer = 0;
            }
        }

        if (damage2.bringBackGen)
        {
            genTimer += Time.deltaTime;

            if (genTimer >= genBack)
            {
                gen2.SetActive(true);
                damage2.shieldHealth = 25;
                damage2.bringBackGen = false;
                genTimer = 0;
            }
        }

    }



    }
