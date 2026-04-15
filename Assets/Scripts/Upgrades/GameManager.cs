using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            changeState(GameState.CardSelection);
            //currentLevel++;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            changeState(GameState.WaveGenerate);
        }
    }*/

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
                currentLevel++;
                break;
            case GameState.NextArea:
                CardManager.Instance.HideCardSelection();
                break;
        }
    }

    // called second
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called third
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Hub")
        {
            currentState = GameState.Hub;
        }
    }


    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public enum GameState
    {
        Playing,
        
        CardSelection,

        WaveGenerate,

        NextArea,

        BossDefeated,

        Hub
    }
}
