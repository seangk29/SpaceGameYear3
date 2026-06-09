using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIncrease : MonoBehaviour
{
    public GameManager gameManager;


    // Update is called once per frame

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameMg").GetComponent<GameManager>();
        gameManager.currentLevel++;
    }
}
