using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardExtras : MonoBehaviour
{

    public List<CardSO> extras = new List<CardSO>();

    public SpecialShotHandler specialShotHandler;

    public CardManager cardManager;

    public void AddSpreadExtras(CardSO extras)
    {
       
        if (specialShotHandler.spreadUnlocked == true)
        {
            cardManager.Upgrades.Add(extras);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //cardManager = GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardManager>();
       // specialShotHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<SpecialShotHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (specialShotHandler == null)
        {
            specialShotHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<SpecialShotHandler>();
        }


        if (cardManager == null)
        {
            cardManager = GameObject.FindGameObjectWithTag("cardManager").GetComponent<CardManager>();
        }

      
    }


    
}
