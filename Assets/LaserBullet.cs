using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LaserBullet : MonoBehaviour
{

    public bool fireLaser;

    public float timer;
    public float timeToStop;

    public GameObject player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       if (fireLaser)
        {
            transform.localScale += new Vector3(0, 0.2f, 0);

            timer += Time.deltaTime;

            if (timer >= timeToStop)
            {
                fireLaser = false;
            }

        }


       transform.position = player.transform.position;
    }
}
