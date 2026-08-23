using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivePlayerHealth : MonoBehaviour
{
    public float speed;
    public float invul = 0;
    public float invulPeriod = 0;

    public float shieldTimer;
    public float regenShieldsTimer = 2;

    public int shieldHealth;
    public int maxShield;

    public int health;  
    public int maxHealth;

    public bool canRegen = false;

    int correctLayer = 6;

    public bool SpRend;
    public bool Combat;
    public bool dodging;

    public AudioSource Daudio;

    // public float fireDelay = 0.25f;
    //  float cooldownTimer = 0;

    
    public PlayerData playerData;
    public PermaPlayerStats playerStats;
    public PlayerSpawner spawn;
    public GameObject sprite;
    public EnemyBulletData enemyBullet;

    public GameObject HUD;

    public GameObject healthFlick;
    public Animator flicker;
    public Animator player;
    public Animator cam;

    public PlayerMovement playerMove;

    private void Start()
    {

        //Wave = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyWaveHandler>();
        
        playerStats = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();
        playerData = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<PlayerData>();
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<PlayerSpawner>();

        HUD = GameObject.FindGameObjectWithTag("HUD").gameObject;

        healthFlick = GameObject.FindGameObjectWithTag("Flicker").gameObject;
        flicker = GameObject.FindGameObjectWithTag("Flicker").GetComponent<Animator>();

        healthFlick.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player1").GetComponent<Animator>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

        maxHealth = playerStats.maxHealth;
        health = maxHealth;

        maxShield = playerStats.maxShield;
        shieldHealth = maxShield;

        regenShieldsTimer = playerStats.regenShieldTimer;

        Combat = true;
        correctLayer =  sprite.gameObject.layer;

        dodging = false;

        SpRend = true;

    }


    
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (SpRend && shieldHealth > 0)
        {
            StartCoroutine(VisualIndicator(Color.cyan));
            Daudio.Play();
        }

        else if (SpRend)
        {
            StartCoroutine(VisualIndicator(Color.red));
            Daudio.Play();
        }

      



        if (collider.gameObject.tag == "Enemy" && dodging == false && playerData != null)
        {

            Daudio.Play();

            cam.SetTrigger("TakeDamage");
            
            if (shieldHealth <= 0)
            {
                playerData.score -= 50;
                health -= 1;
                invul = 1f;
                sprite.gameObject.layer = 8;
                StartCoroutine(VisualIndicator(Color.red));
                cam.SetTrigger("Idle");
            }

            if (shieldHealth > 0)
            {
                shieldHealth--;
                shieldTimer = 0;
                canRegen = true;
                sprite.gameObject.layer = 8;
                StartCoroutine(VisualIndicator(Color.cyan));
                cam.SetTrigger("Idle");
            }
        }

        if (collider.gameObject.tag == "EnemyBullet" && dodging == false && playerData != null)
        {
            Daudio.Play();

            cam.SetTrigger("TakeDamage");

            if (shieldHealth <= 0)
            {
                playerData.score -= 50;
                health -= collider.GetComponent<EnemyBulletData>().damage;
                invul = 1f;
                sprite.gameObject.layer = 8;
                StartCoroutine(VisualIndicator(Color.red));

                cam.SetTrigger("Idle");

            }



            if (shieldHealth > 0)
            {
                shieldHealth -= 1;
                shieldTimer = 0;
                canRegen = true;
            
                StartCoroutine(VisualIndicator(Color.cyan));

                cam.SetTrigger("Idle");

                /* if (SpRend && shieldHealth > 0)
                 {
                     StartCoroutine(VisualIndicator(Color.cyan));
                 }

                 else if (SpRend)
                 {
                     StartCoroutine(VisualIndicator(Color.red));
                 }

                 Daudio.Play();*/
            }
        }

        
    }

    public void HealthUpgrade(int value)
     {
        health = health + value;
        maxHealth = maxHealth + value;
        gameObject.GetComponentInChildren<ActivePlayerHealth>();
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
            sprite.gameObject.layer = correctLayer;
        }
        invul -= Time.deltaTime;

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
       

        if (health == 1)
        {
            healthFlick.SetActive(true);
            flicker.Play("Cosmo Screen Dying 1_Clip");
            player.SetTrigger("Damaged");
            
        }
        else 
        { healthFlick.SetActive(false);

            player.SetTrigger("Idle");
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

        if (playerData == null)
        {
            playerData = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<PlayerData>();
        }

        /*if (Wave != null)
        {
            if (Wave.enemyCount >= Wave.wave3Complete)
            {
                Combat = false;
            }
        }
        else
            return;*/

    }





    private IEnumerator VisualIndicator(Color color)
    {
        GetComponentInChildren<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    IEnumerator Die()
    {

        player.SetTrigger("Dead");
        playerMove.enabled = false;

        yield return new WaitForSeconds(0.5f);
        
        Destroy(gameObject);

        
    }

    public void ExitCombat()
    {
        Combat = false;
    }
}