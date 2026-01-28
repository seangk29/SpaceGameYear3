using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeShot : MonoBehaviour
{

    public PlayerHealth explode;

    public GameObject explodeBullet;
  

    // Start is called before the first frame update
    void Start()
    {
        // change to player
        explode = GetComponent<PlayerHealth>();
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
