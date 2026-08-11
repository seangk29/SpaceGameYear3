using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomUpgrade : MonoBehaviour
{
    [SerializeField] int randomNumber;

    public PermaPlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();

        randomNumber = Random.Range(1, 4);

        switch (randomNumber)
        {
            case 1:
                stats.spreadUnlock(1);
                break;

            case 2:
                stats.laserUnlock(1);
                break;

            case 3:
                stats.explodeUnlock(1);
                break;

            case 4:
                stats.ricochetUnlock(1);
                break;
        }

    }


}
