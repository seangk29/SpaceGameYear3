using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public bool canRegen = false;
    //int correctLayer;
    public bool SpRend;
    public bool Combat;
    public AudioSource Daudio;
    public float fireDelay = 0.25f;
    public EnemyWaveHandler Wave;
    public PlayerData playerData;
    public NewWaveManager NewWave;
    public Animator animator;
    public bool isDying;


    // Start is called before the first frame update
    private void Start()
    {
        Combat = true;
        playerData = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<PlayerData>();
        NewWave = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<NewWaveManager>();

        //correctLayer = gameObject.layer;
        //Wave = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyWaveHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Wave == null)
        {
            Wave = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyWaveHandler>();
        }*/

        if (health <= 0 && isDying == false)
        {
            Die();
        }

        /*if (Wave.enemyCount >= Wave.wave3Complete)
        {
            Combat = false;
        }*/
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (playerData != null)
        {

            if (collider.gameObject.tag == "Bullet" || collider.gameObject.tag == "SpecialBullet")
            {
                Daudio.Play();
                playerData.score = playerData.score + 50;
                health -= collider.GetComponent<BulletData>().damage;

                if (SpRend)
                {
                    StartCoroutine(VisualIndicator(Color.red));
                }

            }

            if (collider.gameObject.tag == "Border")
            {
                NewWave.enemiesKilled = NewWave.enemiesKilled + 1;
                Destroy(gameObject);
            }

        }
    }
    private IEnumerator VisualIndicator(Color color)
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

        isDying = true;

        //NewWave.enemiesKilled += 1; //NewWave.enemiesKilled + 1;
        //playerData.kills += 1; //playerData.kills + 1;
        //animator.SetTrigger("IsDying");
        //animator.SetBool("IsDying", true);
        //animator.Play("Explosion_Clip");
        StartCoroutine(playExplosion());
        //Destroy(gameObject);
        
    }

    IEnumerator playExplosion()
    {
        NewWave.enemiesKilled += 1; //NewWave.enemiesKilled + 1;
        playerData.kills += 1; //playerData.kills + 1;
        //animator.SetTrigger("IsDying");
        //animator.SetBool("IsDying", true);
        animator.Play("Explosion_Clip");
        yield return new WaitForSecondsRealtime(0.5f);
        animator.StopPlayback();
        Destroy(gameObject);
    }

}
