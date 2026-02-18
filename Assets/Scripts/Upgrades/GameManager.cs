using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentLevel = 0;
    public GameState currentState;
    public event Action<GameState> OnStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    // this part is just for testing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            changeState(GameState.CardSelection);
            currentLevel++;
        }
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void changeState(GameState newState)
    { 
        currentState = newState;
        OnStateChanged?.Invoke(newState);
        HandleStateChanged();
    }

    private void HandleStateChanged()
    {
        switch (currentState)
        {
            case GameState.Playing:
                CardManager.Instance.HideCardSelection();
                break;
            case GameState.CardSelection:
                CardManager.Instance.ShowCardSelection();
                break;
        }
    }

    public enum GameState
    {
        Playing,

        CardSelection
    }
}
