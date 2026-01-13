using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGlorgus : MonoBehaviour
{

    Death boss;
    MoveForward moving;
    SelfDestruct self;
    public BossSpawner bossy;

    public float timer;
    public float timeToAttack;
    public float timeToAttack2;

    public float movingTimer;
    public float timeToMove;
    public float timeToMove1;
    public float timeToMove2;
    public float timeToMove3;

    public bool Phase1;
    public bool Phase2;
    public bool startPosPhase2;

    public GameObject GunPos;

    public int phase1complete = 50;



    // Start is called before the first frame update
    void Start()
    {
        boss = GetComponent<Death>();
        moving = GetComponent<MoveForward>();
        self = GetComponent<SelfDestruct>();
        bossy = GetComponent<BossSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Phase1)
        {
            if (boss.health <= phase1complete)
            {
                //moving.movingBackwards = true;
                //self.selfDestruct = true;
                //bossy.BossCount = bossy.BossCount + 1;

                Phase2 = true;
                Phase1 = false;
                startPosPhase2 = true;
                GunPos.SetActive(false);
            }

            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                GunPos.SetActive(false);

                if (timer >= timeToAttack2)
                {
                    GunPos.SetActive(true);
                    timer = 0;
                }
            }
        }

       

     if (Phase2)
        {
            

            if (startPosPhase2)
            {

                Vector3 pos = transform.position;

                pos = new Vector3(-7, 3, 0);

                transform.position = pos;

            }
            
            movingTimer += Time.deltaTime;

                if (movingTimer >= timeToMove)
                {
                    moving.movingForward = false;
                    moving.movingBackwards = false;
                    moving.movingRight = false;
                    moving.movingLeft = true;
                    startPosPhase2 = false;
                }

                if (movingTimer >= timeToMove1)
                {
                    moving.movingForward = false;
                    moving.movingBackwards = false;
                    moving.movingRight = true;
                    moving.movingLeft = false;
                    
                }

                if (movingTimer >= timeToMove2)
                {
                    moving.movingForward = false;
                    moving.movingBackwards = false;
                    moving.movingRight = false;
                    moving.movingLeft = true;
                    
                }

                if (movingTimer >= timeToMove3)
                {
                    moving.movingForward = false;
                    moving.movingBackwards = false;
                    moving.movingRight = true;
                    moving.movingLeft = false;
                    movingTimer = 0;
                }

           
            

           
        }

    }

}
