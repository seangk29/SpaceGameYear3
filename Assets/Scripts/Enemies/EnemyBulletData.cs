using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBulletData : MonoBehaviour
{
    public int baseDamage;
    public int damage;

    public float fireDelay = 0.25f;
    public bool Combat;
    public AudioSource Daudio;

    public int health;


    private void Start()
    {
        Combat = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<ActivePlayerHealth>().health -= damage;
        }

        /*if (collision.gameObject.tag == "Bullet")
        { 
            health -= collision.GetComponent<BulletData>().damage;
        }*/

        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (health <= 0)
        { 
            Destroy(gameObject);
        }
    }
}
