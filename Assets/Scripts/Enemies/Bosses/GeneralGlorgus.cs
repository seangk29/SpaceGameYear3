using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GeneralGlorgus : MonoBehaviour
{

    public BossHealth health;
    public MoveForward move;
    public FacesPlayer face;

    public int phase1complete;
    public int phase2complete;
    public int phase3complete;

    public GlorgusShield glorg;
    public GameObject glorgShield;
    public GameObject gen1;
    public GameObject gen2;
    public float Atimer;
    public float timeToShield;

    public float Btimer;
    public float timeToAttack;
    public bool glorgusAttack;

    public float Ctimer;
    public float timeToGo;
    public bool phase2;
    public bool newPos;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;

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
        move = GetComponent<MoveForward>();
        face = GetComponent<FacesPlayer>();
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
            glorgusAttack = false;
            gen1.SetActive(false);
            gen2.SetActive(false);
            glorgShield.SetActive(false);
            move.enabled = true;
            face.enabled = false;

            phase2 = true;

        }

        if (phase2)
        {
            Ctimer += Time.deltaTime;


            if (Ctimer >= timeToGo)
            {
                int rand = Random.Range(0, 8);
                newPos = true;
                gun1.SetActive(true);
                gun2.SetActive(true);
                gun3.SetActive(true);

                switch (rand)
                {
                    case 0:
                        phase2Attack1();
                        break;
                    case 1:
                        phase2Attack2();
                        break;
                    case 2:
                        phase2Attack3();
                        break;
                    case 3:
                        phase2Attack4();
                        break;
                    case 4:
                        phase2Attack5();
                        break;
                    case 5:
                        phase2Attack6();
                        break;
                    case 6:
                        phase2Attack7();
                        break;
                    case 7:
                        phase2Attack8();
                        break;
                    case 8:
                        phase2Attack9();
                        break;



                }
            }

        }

    }

    void phase2Attack1()
    {
        
        if (newPos)
        {
            Vector3 pos = transform.position;

            pos = new Vector3(0, 4f, 0);

            transform.position = pos;

            Quaternion rot = transform.rotation;

            rot = Quaternion.Euler(0, 0, 180);

            transform.rotation = rot;

            newPos = false;
        }

        move.movingBackwards = false;
        move.movingForward = true;

        Ctimer = 0;


    }

    void phase2Attack2()
    {

        if (newPos)
        {
            Vector3 pos = transform.position;

            pos = new Vector3(-9, 0.5f, 0);

            transform.position = pos;

            Quaternion rot = transform.rotation;

            rot = Quaternion.Euler(0, 0, -90);

            transform.rotation = rot;

            newPos = false;
        }

        move.movingBackwards = false;
        move.movingForward = true;

        Ctimer = 0;


    }

    void phase2Attack3()
    {

        if (newPos)
        {
            Vector3 pos = transform.position;

            pos = new Vector3(9, 0.5f, 0);

            transform.position = pos;

            Quaternion rot = transform.rotation;

            rot = Quaternion.Euler(0, 0, 90);

            transform.rotation = rot;

            newPos = false;
        }

        move.movingBackwards = false;
        move.movingForward = true;

        Ctimer = 0;


    }

    void phase2Attack4()
    {

        if (newPos)
        {
            Vector3 pos = transform.position;

            pos = new Vector3(-6, 4f, 0);

            transform.position = pos;

            Quaternion rot = transform.rotation;

            rot = Quaternion.Euler(0, 0, 180);

            transform.rotation = rot;

            newPos = false;
        }

        move.movingBackwards = false;
        move.movingForward = true;

        Ctimer = 0;


    }

    void phase2Attack5()
    {

        if (newPos)
        {
            Vector3 pos = transform.position;

            pos = new Vector3(6, 4f, 0);

            transform.position = pos;

            Quaternion rot = transform.rotation;

            rot = Quaternion.Euler(0, 0, 180);

            transform.rotation = rot;

            newPos = false;
        }

        move.movingBackwards = false;
        move.movingForward = true;

        Ctimer = 0;


    }


    void phase2Attack6()
    {

        if (newPos)
        {
            Vector3 pos = transform.position;

            pos = new Vector3(9, 2.5f, 0);

            transform.position = pos;

            Quaternion rot = transform.rotation;

            rot = Quaternion.Euler(0, 0, 90);

            transform.rotation = rot;

            newPos = false;
        }

        move.movingBackwards = false;
        move.movingForward = true;

        Ctimer = 0;


    }


    void phase2Attack7()
    {

        if (newPos)
        {
            Vector3 pos = transform.position;

            pos = new Vector3(9, -2.5f, 0);

            transform.position = pos;

            Quaternion rot = transform.rotation;

            rot = Quaternion.Euler(0, 0, 90);

            transform.rotation = rot;

            newPos = false;
        }

        move.movingBackwards = false;
        move.movingForward = true;

        Ctimer = 0;


    }

    void phase2Attack8()
    {

        if (newPos)
        {
            Vector3 pos = transform.position;

            pos = new Vector3(-9, 2.5f, 0);

            transform.position = pos;

            Quaternion rot = transform.rotation;

            rot = Quaternion.Euler(0, 0, -90);

            transform.rotation = rot;

            newPos = false;
        }

        move.movingBackwards = false;
        move.movingForward = true;

        Ctimer = 0;


    }

    void phase2Attack9()
    {

        if (newPos)
        {
            Vector3 pos = transform.position;

            pos = new Vector3(9, -2.5f, 0);

            transform.position = pos;

            Quaternion rot = transform.rotation;

            rot = Quaternion.Euler(0, 0, -90);

            transform.rotation = rot;

            newPos = false;
        }

        move.movingBackwards = false;
        move.movingForward = true;

        Ctimer = 0;
        


    }

}




