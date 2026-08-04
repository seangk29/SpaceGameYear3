using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlorgusPhase2 : MonoBehaviour
{

    public BossHealth health;
    public MoveForward move;
    public FacesPlayer face;
    public GlorgusPhase1 phase1;
    public GlorgusPhase3 phase3;


    public int phase2complete;

    public float Ctimer;
    public float timeToGo;
    public bool phase2;
    public bool newPos;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;

    public GameObject gen1;
    public GameObject gen2;
    public GameObject glorgShield;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<BossHealth>();
        move = GetComponent<MoveForward>();
        face = GetComponent<FacesPlayer>();
        phase1 = GetComponent<GlorgusPhase1>();
        phase3 = GetComponent<GlorgusPhase3>();

        phase1.enabled = false;


     
        gen1.SetActive(false);
        gen2.SetActive(false);
        glorgShield.SetActive(false);
        move.enabled = true;
        face.enabled = false;
    }

    // Update is called once per frame
    void Update()
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

        if (health.health <= phase2complete)
        {
            phase3.enabled = true;
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
