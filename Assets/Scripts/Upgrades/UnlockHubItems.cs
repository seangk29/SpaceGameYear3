using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockHubItems : MonoBehaviour
{
    public GameObject Nicos;
    public PlayerData counter;
    public bool spawned = false;
    public int bossCounts;

    public PauseMenu paus;

    public DialogueController control;

    public GameObject skips;

    public GameObject nics;


    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
        bossCounts = counter.bossCount;
    }



    // Update is called once per frame
    void Update()
   {
        if (bossCounts >= 3 && spawned == false)
        {
            spawned = true;
            Nicos.SetActive(true);
        }

        if (control.skipBool == true)
        {
            skips.SetActive(false);
            paus.shooting.enabled = false;
        }

        if (control.nicoBool == true)
        {
            nics.SetActive(false);
        }

    }


}
