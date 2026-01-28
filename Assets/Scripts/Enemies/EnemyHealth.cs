using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    private void Start()
    {
        Combat = true;
       // correctLayer = gameObject.layer;
        Wave = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemyWaveHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }

        if (Wave.enemyCount >= Wave.wave3Complete)
        {
            Combat = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Combat)
        {

            if (collider.gameObject.tag == "Bullet")
            {
                health--;
            }

            if (SpRend)
            {
                StartCoroutine(VisualIndicator(Color.red));
            }

            Daudio.Play();

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
            Wave.enemyCount = Wave.enemyCount + 1;
            Debug.Log("Shot!");
            Debug.Log(Wave.enemyCount);
        }

        Destroy(gameObject);
    }
}
