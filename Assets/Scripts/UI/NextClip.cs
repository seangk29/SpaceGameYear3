using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextClip : MonoBehaviour
{
    MusicLoop clips;

    public double timer = 0;

    public double timeToChange;

    public AudioClip clip;
    

    // Start is called before the first frame update
    void Start()
    {
        clips = GetComponent<MusicLoop>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
