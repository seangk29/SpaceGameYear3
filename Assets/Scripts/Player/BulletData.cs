using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public int baseDamage;
    public int damage;

    public int health;

    public PermaPlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();
        damage = playerStats.damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
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
