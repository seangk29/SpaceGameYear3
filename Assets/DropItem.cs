using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{

    public GameObject scoreItem;
    public GameObject healthItem;
    public GameObject ammoItem;
    public EnemyHealth health;

    public Transform trans;

    public bool giveItem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (giveItem)
        {

           int rand = Random.Range(0, 100 );
            
            if (rand >= 0 && rand <= 1)
            {
                Instantiate(ammoItem, transform.position, trans.rotation);
                giveItem = false;
            }

            if (rand >= 2 && rand <= 4)
            {
                Instantiate(healthItem, transform.position, trans.rotation);
                giveItem = false;
            }

            if (rand >= 5 && rand <= 25)
            {
                Instantiate(scoreItem, transform.position, trans.rotation);
                giveItem = false;
            }

            if (rand >= 26 && rand <= 100)
            {
                giveItem = false;
            }


        }
       
    }
}
