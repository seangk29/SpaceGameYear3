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

    public GameObject enemy;

    public GameManager gameMg;

    public BoxCollider2D boxCollider;


    private void Start()
    {
        Combat = true;

       gameMg = GameObject.FindGameObjectWithTag("GameMg").GetComponent<GameManager>();

        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<ActivePlayerHealth>().health -= damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            boxCollider.enabled = false;
        }
        
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        boxCollider.enabled = true;
    }

    private void Update()
    {
        if (health <= 0)
        { 
            Destroy(gameObject);
        }

       if (gameMg.currentState == GameManager.GameState.CardSelection)
        {
            Destroy(gameObject);
        }

        
        
    }
}
