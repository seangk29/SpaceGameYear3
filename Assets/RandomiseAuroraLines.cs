using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomiseAuroraLines : MonoBehaviour
{

    public PlayerData data;

    public int auroraLine;

    public GameObject sayTheLine;
    
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<PlayerData>();

       
        if (data.hasMetAuora)
        {
            auroraLine = Random.Range(1, 3);

            switch (auroraLine)
            {
                case 1:
                    sayTheLine.SetActive(true);
                    break;
                case 2:
                    sayTheLine.SetActive(false);
                    break;
                case 3:
                    sayTheLine.SetActive(false);
                    break;

            }
        }

        
    }


}
