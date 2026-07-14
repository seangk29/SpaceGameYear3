using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePlayerItem : MonoBehaviour
{

    public ActivePlayerHealth health;
    public PlayerShooting shooting;
    public PlayerData data;

    public int scoreIncreaseNumber;
    public int healthIncreaseNumber;
    public int ammoIncreaseNumber;


    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<PlayerData>();
        shooting = GameObject.FindGameObjectWithTag("GunPos").GetComponent<PlayerShooting>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<ActivePlayerHealth>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "scoreDrop")
        {
            data.score += scoreIncreaseNumber;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ammoDrop")
        {
            shooting.specialAmmo += ammoIncreaseNumber;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "healthDrop")
        {
            health.health += healthIncreaseNumber;
            Destroy(collision.gameObject);
        }
    }
}
