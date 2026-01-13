using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    PlayerData player;
    
    public TextMeshProUGUI scoreTMP;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTMP.text = "SCORE: " + player.score;
    }
}
