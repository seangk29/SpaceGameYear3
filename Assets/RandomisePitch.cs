using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomisePitch : MonoBehaviour
{

   public AudioSource fire;
    

    // Start is called before the first frame update
    void Start()
    {
        fire = GetComponent<AudioSource>();

        fire.pitch = Random.Range(0.75f, 1.25f);
    }

    
}
