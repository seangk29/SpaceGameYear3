using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGlorgus : MonoBehaviour
{

    public BossHealth health;

    public int phase1complete;
    public int phase2complete;
    public int phase3complete;


    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health.health <=  phase1complete)
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


        }






    }

}


