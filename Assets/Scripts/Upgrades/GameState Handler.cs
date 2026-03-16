using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{

    public GameManager manager;
    public CardManager cardManager;
    public NewWaveManager newWaveManager;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged -= HandleGameStateChanged;
        }
    }

    private void HandleGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.CardSelection)
        {
            cardManager.gameObject.SetActive(true);
            CardManager.Instance.RandomizeNewCards();
        }

        if (state == GameManager.GameState.WaveGenerate)
        {
            cardManager.gameObject.SetActive(false);
            NewWaveManager.Instance.RandomizeNewWaves();
        }
    }
}
