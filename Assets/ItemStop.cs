using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStop : MonoBehaviour
{

    public GameManager gameMg;
    public MoveForward move;
    
    
    // Start is called before the first frame update
    void Start()
    {
        move = this.GetComponent<MoveForward>();
        gameMg = GameObject.FindGameObjectWithTag("GameMg").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMg.currentState == GameManager.GameState.CardSelection)
        {
            move.enabled = false;
        }
    }
}
