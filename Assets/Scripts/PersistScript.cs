using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistScript : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameManager = GameObject.FindGameObjectWithTag("GameMg").GetComponent<GameManager>();
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
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        if (scene.name == "MainMenu" || scene.name == "ResetStats" || scene.name == "Ending"/*and quitscene*/)
        {
            Destroy(gameObject);
        }
        if (scene.name == "NewWavesSystemTest" ||  scene.name == "NoPDGameplay")
        {
            StartCoroutine(waitTimer());
            GameManager.Instance.changeState(GameManager.GameState.WaveGenerate);
        }
    }


    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    IEnumerator waitTimer()
    {
        yield return new WaitForSecondsRealtime(3);
        GameManager.Instance.changeState(GameManager.GameState.WaveGenerate);
    }
}
