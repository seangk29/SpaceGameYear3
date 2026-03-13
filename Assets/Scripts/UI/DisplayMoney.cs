using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
    PlayerData player;

    public TextMeshProUGUI moneyTMP;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyTMP.text = "MONEY: " + player.spaceMoney;
    }

}
