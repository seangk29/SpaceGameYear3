using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeShot : MonoBehaviour
{

    

    public BulletData bullet;

    public GameObject explodeBullet;
  

    // Start is called before the first frame update
    void Start()
    {
        // change to player
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(explodeBullet, transform.position, transform.rotation);
            return;
        }
    }
}
