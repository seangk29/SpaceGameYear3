using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public double goalTime;
    public double musicDuration;
    public double clipDuration;

    public AudioSource[] audioSources;
    public AudioClip currentClip;

    public AudioClip newClip;

    public int audioToggle;

    public int count = 0;

    void PlayScheduledClip()
    {
        audioSources[audioToggle].clip = currentClip;   
        audioSources[audioToggle].PlayScheduled(goalTime);

        musicDuration = (double)currentClip.samples / currentClip.frequency;
        goalTime = goalTime + musicDuration;

        audioToggle = 1 - audioToggle;

        count = count + 1;  
    }

    private void Awake()
    {
        goalTime = AudioSettings.dspTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (AudioSettings.dspTime > goalTime - 1)
        {
           PlayScheduledClip();
        }

        if (count >= 3)
        {
            currentClip = newClip;

        }
    }

    
}
