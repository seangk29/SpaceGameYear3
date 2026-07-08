using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject GunPos;

    public bool gunBot;

    public FacesEnemy face;

    public float timer = 0;
    public float timeToAttack;
    public bool Fire = false;

    public bool canFire = true;


    // Update is called once per frame

  
    void FixedUpdate()
    {
        //int rand = Random.Range(2, 7);


        if (canFire)
        {
            timer += Time.deltaTime;
        }


       // timer += Time.deltaTime;

        if (timer >= timeToAttack)
        {
            Fire = true;
        }

        if (gunBot)
        {
            if (face.enemy == null)
            {
                canFire = false;
            }
            else
            {
                canFire = true;
            }
        }

        if (Fire)
        {
           
            Instantiate(bulletPrefab, transform.position, transform.rotation);

            timer = 0;

            Fire = false;
        
        
        }
    }
}
