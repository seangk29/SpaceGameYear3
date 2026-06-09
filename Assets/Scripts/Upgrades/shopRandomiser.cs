using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopRandomiser : MonoBehaviour
{
    [SerializeField] int[] randomNumbers;
    public int[] retainnumbers;

    [SerializeField] public List<CardSO> Upgrades;

   [SerializeField] public List<CardSO> randomizedCards = new List<CardSO>();



    private void Awake()
    {
        for (int i = 0; i < randomNumbers.Length; i++)
        {
         randomNumbers[i] = Random.Range(1, 6);
            
        }

        if (randomNumbers[0] == randomNumbers[1])
        {
            randomNumbers[1] = Random.Range(1, 6);
        }
        else if (randomNumbers[1] == randomNumbers[2])
        {
            randomNumbers[2] = Random.Range(1, 6);
        }
        else if (randomNumbers[2] == randomNumbers[1])
        {
            randomNumbers[2] = Random.Range(1, 6);
        }
        else if (randomNumbers[0] == randomNumbers[2])
        {
            randomNumbers[2] = Random.Range(1, 6);
        }

        for (int i = 0; i < randomNumbers.Length; i++)
        {
            retainnumbers[i] = randomNumbers[i];

        }

    }


    // Update is called once per frame
    void Update()
    {
      List<CardSO> availableCards = new List<CardSO>(Upgrades);

        for (int i = 0; i < randomNumbers.Length; i++)
        {

            switch (randomNumbers[i])
            {
                case 1:
                    randomizedCards.Add(availableCards[0]);
                    randomNumbers[i] = 0;
                    break;

                case 2:
                    randomizedCards.Add(availableCards[1]);
                    randomNumbers[i] = 0;
                    break;

                case 3:
                    randomizedCards.Add(availableCards[2]);
                    randomNumbers[i] = 0;
                    break;

                case 4:
                    randomizedCards.Add(availableCards[3]);
                    randomNumbers[i] = 0;
                    break;

                case 5:
                    randomizedCards.Add(availableCards[4]);
                    randomNumbers[i] = 0;
                    break;

                case 6:
                    randomizedCards.Add(availableCards[5]);
                    randomNumbers[i] = 0;
                    break;

                case 7:
                    randomizedCards.Add(availableCards[6]);
                    randomNumbers[i] = 0;
                    break;
            }

        }
    }
}
