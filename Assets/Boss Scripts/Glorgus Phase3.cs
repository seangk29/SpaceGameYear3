using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlorgusPhase3 : MonoBehaviour
{

  

    public BossHealth health;
    public MoveForward move;
    public FacesPlayer face;
    public GlorgusPhase2 phase2;

    public DamageToShields damage1;
    public DamageToShields damage2;
    public DamageToShields damage3;
    public DamageToShields damage4;

    public float genTimer;
    public float genBack;


    public int phase1complete;

    public GlorgusShield glorg;
    public GameObject glorgShield;
    public GameObject gen1;
    public GameObject gen2;
    public GameObject gen3;
    public GameObject gen4;
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

    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;


    // Start is called before the first frame update
    void Start()
    {
        phase2 = GetComponent<GlorgusPhase2>();
        phase2.enabled = false;


        Vector3 pos = transform.position;

        pos = new Vector3(0, 2.5f, 0);

        transform.position = pos;

        Quaternion rot = transform.rotation;

        rot = Quaternion.Euler(0, 0, 180);

        transform.rotation = rot;

        face.enabled = true;
        move.enabled = false;

        gen1.SetActive(true);
        gen2.SetActive(true);
        gen3.SetActive(true);
        gen4.SetActive(true);

        gun1.SetActive(false);
        gun2.SetActive(false);
        gun3.SetActive(false);

        glorgShield.SetActive(true);
        glorg.shieldHealth = 100;
        

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

        if (damage3.bringBackGen)
        {
            genTimer += Time.deltaTime;

            if (genTimer >= genBack)
            {
                gen3.SetActive(true);
                damage3.shieldHealth = 25;
                damage3.bringBackGen = false;

                genTimer = 0;
            }
        }

        if (damage4.bringBackGen)
        {
            genTimer += Time.deltaTime;

            if (genTimer >= genBack)
            {
                gen4.SetActive(true);
                damage4.shieldHealth = 25;
                damage4.bringBackGen = false;
                genTimer = 0;
            }
        }
    }
}
