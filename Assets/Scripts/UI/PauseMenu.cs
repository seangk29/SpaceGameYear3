using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject pMenu;
    public GameObject confirmHubMenu;
    public GameObject confirmMenu;

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

    public void Hub()
    {
        confirmHubMenu.SetActive(true);
    }

    public void ConfirmHubExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Hub");
    }

    public void DenyHubExit()
    {
        confirmHubMenu.SetActive(false);
    }

    public void ConfirmExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void DenyExit()
    {
        confirmMenu.SetActive(false);
    }

    public void Exit()
    {
        confirmMenu.SetActive(true);
    }
}
