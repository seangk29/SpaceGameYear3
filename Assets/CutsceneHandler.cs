using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneHandler : MonoBehaviour
{

    public GameObject[] cutsceneMusic;

    public PlayerData data;

    public GameObject[] cutscenes;
    
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<PlayerData>();

        switch (data.cutSceneCounter)
        {
            case 0:
                cutsceneMusic[0].SetActive(true);
                data.cutSceneCounter += 1;
                cutscenes[0].SetActive(true);
                data.hasMetAuora = true;
                break;

            case 1:
                cutsceneMusic[0].SetActive(false);
                cutscenes[0].SetActive(false);

                cutscenes[1].SetActive(true);
                cutsceneMusic[1].SetActive(true);
                data.cutSceneCounter += 1;
                break;

            case 2:
                cutsceneMusic[1].SetActive(false);
                cutscenes[1].SetActive(false);

                cutscenes[2].SetActive(true);
                cutsceneMusic[2].SetActive(true);
                data.cutSceneCounter += 1;
                break;

            case 3:
                cutsceneMusic[2].SetActive(false);
                cutscenes[2].SetActive(false);

                cutscenes[3].SetActive(true);
                cutsceneMusic[3].SetActive(true);
                data.cutSceneCounter += 1;
                break;

            case 4:
                cutsceneMusic[3].SetActive(false);
                cutscenes[3].SetActive(false);

                cutscenes[4].SetActive(true);
                cutsceneMusic[4].SetActive(true);
                data.cutSceneCounter += 1;
                break;

            case 5:
                cutsceneMusic[4].SetActive(false);
                cutscenes[4].SetActive(false);

                cutscenes[5].SetActive(true);
                cutsceneMusic[5].SetActive(true);
                data.cutSceneCounter += 1;
                break;

            case 6:
                cutsceneMusic[5].SetActive(false);
                cutscenes[5].SetActive(false);

                cutscenes[6].SetActive(true);
                cutsceneMusic[6].SetActive(true);
                data.cutSceneCounter += 1;
                break;

            case 7:
                cutsceneMusic[6].SetActive(false);
                cutscenes[6].SetActive(false);

                cutscenes[7].SetActive(true);
                cutsceneMusic[7].SetActive(true);
                data.cutSceneCounter += 1;
                break;

            case 8:
                cutsceneMusic[7].SetActive(false);
                cutscenes[7].SetActive(false);

                cutscenes[8].SetActive(true);
                cutsceneMusic[8].SetActive(true);
                data.cutSceneCounter = 0;
                break;

        }
    }

   
}
