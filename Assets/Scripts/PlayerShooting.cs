using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject SbulletPrefab;
    public GameObject GunPos;

    public static bool MakingChoice = false;

    public AudioSource Paudio;
    public AudioSource SPaudio;


    public float fireDelay = 0.25f;
    public float SPfireDelay = 3f;
    float cooldownTimer = 0;
    
    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

       if (MakingChoice == false)
        {
            if (Input.GetKey(KeyCode.Mouse0) && cooldownTimer <= 0)
            {
                cooldownTimer = fireDelay;

                Paudio.Play();

                Instantiate(bulletPrefab, transform.position, transform.rotation);


            }


            if (Input.GetKey(KeyCode.Mouse1) && cooldownTimer <= 0)
            {
                cooldownTimer = SPfireDelay;

                SPaudio.Play();

                Instantiate(SbulletPrefab, transform.position, transform.rotation);


            }
        }
        
        

    }
}
