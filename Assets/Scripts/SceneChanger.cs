using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("DHDHHFHD");

        if (Input.GetKey(KeyCode.E))
        {
            NextLevel();
            Debug.Log("DHDHHFHD");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync("ResetStats");
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }




    // all this is for reseting stats on retry
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // called third
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "ResetStats")
        {
            StartCoroutine(resetTimer());
        }
        if (scene.name == "Start Gameplay")
        { 
            StartCoroutine(startTimer());
        }
    }

    IEnumerator resetTimer()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadSceneAsync("PostGameplayHub");
    }

    IEnumerator startTimer()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadSceneAsync("NoPDGameplay");
    }
}
