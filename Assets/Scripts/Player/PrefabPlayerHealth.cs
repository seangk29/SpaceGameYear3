using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float speed;
    public float invul = 0;
    public float invulPeriod = 0;

    public float shieldTimer;
    public float regenShieldsTimer;

    public int shieldHealth;
    public int maxShield;

    public int health;  
    public int maxHealth;

    public bool canRegen = false;

    int correctLayer;

    public bool SpRend;
    public bool Combat;

    public AudioSource Daudio;

    public float fireDelay = 0.25f;
    //  float cooldownTimer = 0;

    public PlayerSpawner playerSpawn;
    public EnemyWaveHandler Wave;

    private void Start()
    {
        maxHealth = health;
        Combat = true;
        correctLayer = gameObject.layer;
        Wave = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyWaveHandler>();
        playerSpawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSpawner>();

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Combat)
        {
            if (shieldHealth <= 0)
            {
                health--;
                invul = 0.50f;
                gameObject.layer = 8;
            }

            if (shieldHealth > 0)
            {
                shieldHealth--;
                shieldTimer = 0;
                canRegen = true;
                invul = 0.50f; ;
                gameObject.layer = 8;
            }

            if (SpRend && shieldHealth > 0)
            {
                StartCoroutine(VisualIndicator(Color.cyan));
            }

            else if (SpRend)
            {
                StartCoroutine(VisualIndicator(Color.red));
            }

            Daudio.Play();
        }

        if (collider.gameObject.tag == "HealthPack")
        {
            health = health - 50;
            playerSpawn.numLives = playerSpawn.numLives + 1;
        }
    }

    public void HealthUpgrade(int value)
     {
        health = health + value;
        maxHealth = maxHealth + value;
        gameObject.GetComponentInChildren<PlayerHealth>();
        Debug.Log("shouldve upgraded health");
    }

    public void ShieldUpgrade(int value)
    {
        shieldHealth = shieldHealth + value;
        maxShield = maxShield + value;
        Debug.Log("Choice");

    }

    private void Update()
    {
        if (invul <= 0)
        {
            gameObject.layer = correctLayer;
        }
        invul -= Time.deltaTime;

        if (health <= 0)
        {
            Die();
        }

            if (canRegen)
            {
                shieldTimer += Time.deltaTime;

                if (shieldTimer >= regenShieldsTimer)
                {
                    shieldHealth = shieldHealth + 1;
                    shieldTimer = 0;

                    if (shieldHealth >= maxShield)
                    {
                        shieldTimer = 0;
                        canRegen = false;
                    }
                }
            }

        if (Wave != null)
        {
            if (Wave.enemyCount >= Wave.wave3Complete)
            {
                Combat = false;
            }
        }
        else
            return;

    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void ExitCombat()
    {
        Combat = false;
    }
}