using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;


using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public int health;
    public float invul = 0;
    public float invulPeriod = 0;

    public bool canRegen = false;

    int correctLayer;

    public bool SpRend;
    public bool Combat;

    public AudioSource Daudio;

    public float fireDelay = 0.25f;

    PlayerData playerData;
    GameManager gameManager;
    //  float cooldownTimer = 0;
   

    //public EnemyWaveHandler Wave;
   

    private void Start()
    {

        playerData = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<PlayerData>();
        gameManager = GameObject.FindGameObjectWithTag("GameMg").GetComponent<GameManager>();

        Combat = true;
        correctLayer = gameObject.layer;
        //Wave = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyWaveHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Combat)
        {

            if (SpRend)
            {
                StartCoroutine(VisualIndicator(Color.red));
            }

            //Daudio.Play();

        }

        if (collider.gameObject.tag == "Bullet" || collider.gameObject.tag == "SpecialBullet")
        {
            Daudio.Play();
            playerData.score = playerData.score + 50;
            health -= collider.GetComponent<BulletData>().damage;

        }
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
    }

    private IEnumerator VisualIndicator (Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

   public void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            //Wave.enemyCount = Wave.enemyCount + 1;
            Debug.Log("Shot!");
            //Debug.Log(Wave.enemyCount);
        }
        GameManager.Instance.changeState(GameManager.GameState.BossDefeated);
        Destroy(gameObject);
    }


    public void ExitCombat()
    {
        Combat = false;
    }

}