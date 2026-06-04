using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNextArea : MonoBehaviour
{
    public PauseMenu paus;
    public DialogueController control;
    public GameObject nextArea;
    public GameObject interact;
    public GameManager gameManager;
    

    // Update is called once per frame

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameMg").GetComponent<GameManager>();
        gameManager.currentLevel++;
    }

    void Update()
    {
        if (control.activatorBool == true)
        {
            nextArea.SetActive(false);
            interact.SetActive(false);
            paus.shooting.enabled = false;
        }


    }




}
