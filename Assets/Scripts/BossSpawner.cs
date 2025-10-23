using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject Boss;
    public int BossCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void Update()
    {
        if (BossCount == 0)
        {
            Instantiate(Boss);
            BossCount = BossCount + 1;
        }

    }


}
