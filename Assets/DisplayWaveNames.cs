using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayWaveNames : MonoBehaviour
{
    public TextMeshProUGUI waveTMP;

    public NewWaveManager wave;

    // Start is called before the first frame update
    void Start()
    {
        //gameMG = GameObject.FindGameObjectWithTag("GameMG").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        wave = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<NewWaveManager>();
        waveTMP.text = "WAVE:  " + wave.currentWave.waveName;
    }
}
