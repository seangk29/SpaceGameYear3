using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletData : MonoBehaviour
{
    public int baseDamage;
    public int damage;
    public bool special;
    public int health;

    public PermaPlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();
        if (special)
        {
            damage = playerStats.specialDamage;
            health = playerStats.spBulletHealth;
        }
        else
        {
            damage = playerStats.damage;
            health = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }

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
