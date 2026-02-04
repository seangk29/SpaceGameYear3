using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSearching : MonoBehaviour
{

    PlayerHealth playerHealth;
    public int health;
    public int shield;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerHealth>();
        playerHealth.maxHealth = health;
        playerHealth.maxShield = shield;
    }

    private void Update()
    {
        if (playerHealth.canRegen)
        {
            playerHealth.shieldTimer += Time.deltaTime;

            if (playerHealth.shieldTimer >= playerHealth.regenShieldsTimer)
            {
                playerHealth.shieldHealth = playerHealth.shieldHealth + 1;
                playerHealth.shieldTimer = 0;

                if (playerHealth.shieldHealth >= playerHealth.maxShield)
                {
                    playerHealth.shieldTimer = 0;
                    playerHealth.canRegen = false;
                }
            }
        }

        if (health <= 0)
        {
            Die();
        }


    }

    public void heal(int value)
    {
        health = health + value;
    }

    public void Die()
    { 
        Destroy(gameObject);
    }
}
