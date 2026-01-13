using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeShot : MonoBehaviour
{

    public Death explode;

    public GameObject explodeBullet;
  

    // Start is called before the first frame update
    void Start()
    {
        explode = GetComponent<Death>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (explode.health <= 0)
        {
            Instantiate(explodeBullet, transform.position, transform.rotation);
            return;
        }
    }
}
