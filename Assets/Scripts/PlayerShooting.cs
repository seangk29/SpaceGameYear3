using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject SbulletPrefab;
    public GameObject GunPos;

    public AudioSource Paudio;
    

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    
    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if(Input.GetKey(KeyCode.Mouse0) && cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            Paudio.Play();

            Instantiate(bulletPrefab, transform.position, transform.rotation);


        }


        if (Input.GetKey(KeyCode.Mouse1) && cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            

            Instantiate(SbulletPrefab, transform.position, transform.rotation);


        }

    }
}
