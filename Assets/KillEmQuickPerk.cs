using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEmQuickPerk : MonoBehaviour
{
    public float timer;
    public float timeToLoseAmmo;

    public PlayerShooting shoot;
    public EnemyHealth eHealth;

    public bool killEmQuickActive;
    //Remember to put a gotKilled Bool in EnemyHealth



    void Start()
    {


        shoot = GameObject.FindGameObjectWithTag("GunPos").GetComponent<PlayerShooting>();
       
        killEmQuickActive = true;



    }


    void Update()
    {

       // eHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();

        timer += Time.deltaTime;

        if (timer >= timeToLoseAmmo)
        {

            shoot.specialAmmo = 0;

        }

        if (eHealth.gotKilled)
        {
            timer = 0;
            shoot.specialAmmo = shoot.specialAmmo + 1;

        }



    }

}
