using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject SbulletPrefab;


    public GameObject GunPos;

    public static bool MakingChoice = false;
    

    


    public float fireDelay = 0.25f;
    public float SPfireDelay = 3f;
    float cooldownTimer = 0;
    float ScooldownTimer = 0;

    public PlayerMovement Special;

    public void Start()
    {
        PlayerMovement Special = GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        ScooldownTimer -= Time.deltaTime;

        if (MakingChoice == false)
        {
            if (Input.GetKey(KeyCode.Mouse0) && cooldownTimer <= 0)
            {
                cooldownTimer = fireDelay;

                

                Instantiate(bulletPrefab, transform.position, transform.rotation);


            }


            if (Input.GetKey(KeyCode.Mouse1) && ScooldownTimer <= 0 && Special.CanUseSpecial == true)
            {
             

                ScooldownTimer = SPfireDelay;

                

                Instantiate(SbulletPrefab, transform.position, transform.rotation);


            }
        }
        
       



    }
}
