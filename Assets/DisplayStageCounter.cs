using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayStageCounter : MonoBehaviour
{
    public TextMeshProUGUI stageTMP;

    public GameManager gameMG;

    // Start is called before the first frame update
    void Start()
    {
        //gameMG = GameObject.FindGameObjectWithTag("GameMG").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        gameMG = GameObject.FindGameObjectWithTag("GameMg").GetComponent<GameManager>();
        stageTMP.text = "STAGE " + gameMG.currentLevel;
    }
}
