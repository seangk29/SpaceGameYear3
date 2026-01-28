using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject pMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            pMenu.SetActive(true);
            PauseGame();
        }
        
    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            pMenu.SetActive(false);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pMenu.SetActive(false);
    }

    public void Exit(string MainMenu)
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(MainMenu);
    }
}
