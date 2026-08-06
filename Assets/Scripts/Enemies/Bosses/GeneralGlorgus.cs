using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class GeneralGlorgus : MonoBehaviour
{

    public GlorgusPhase1 phase1;
    
    
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
    public GameObject gen3;
    public GameObject gen4;
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

    public bool phase3;
    public bool phase3Pos;
    public float Dtimer;
    public float timeToContinue;
    public bool comeBack;

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
       
        phase1.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
    }
}




