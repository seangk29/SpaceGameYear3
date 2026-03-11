using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    public PlayerShooting shooting;
    public GameObject pMenu;
    public GameObject confirmHubMenu;
    public GameObject confirmMenu;



    private void Update()
    {
        shooting = GameObject.FindGameObjectWithTag("GunPos").GetComponent<PlayerShooting>();


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
            shooting.enabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            pMenu.SetActive(false);
            shooting.enabled = true;
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

    public void Retry()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

}
