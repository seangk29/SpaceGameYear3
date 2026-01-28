using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject GunPos;

    public AudioSource Eaudio;

    public float timer = 0;
    public float timeToAttack;
    public bool Fire = false;
  

    // Update is called once per frame



    void FixedUpdate()
    {
        //int rand = Random.Range(2, 7);
        timer += Time.deltaTime;

        if (timer >= timeToAttack)
        {
            Fire = true;
        }

      

        if (Fire)
        {
            Eaudio.Play();

            Instantiate(bulletPrefab, transform.position, transform.rotation);

            timer = 0;

            Fire = false;
        
        
        }
    }
}
