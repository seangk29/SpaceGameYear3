using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayPauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    public PlayerShooting shooting;
    public GameObject pMenu;
    public GameObject confirmHubMenu;
    public GameObject confirmMenu;

    public Button pauseButton;

    PlayerControls controls;


    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Pause.performed += ctx => PlayerPausesGame();
    }

    private void Start()
    {
        if (shooting == null)
        {
            shooting = GameObject.FindGameObjectWithTag("GunPos").GetComponent<PlayerShooting>();
        }
    }
    private void Update()
    {
        shooting = GameObject.FindGameObjectWithTag("GunPos").GetComponent<PlayerShooting>();

        PlayerPausesGame();
        

    }

    void PlayerPausesGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || controls.Gameplay.Pause.IsPressed())
        {
            gameIsPaused = true;
            pMenu.SetActive(true);
            PauseGame();
            pauseButton.Select();
        }
    }


    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            shooting.enabled = false;

            if (Input.GetKeyDown(KeyCode.Escape) || controls.Gameplay.Pause.IsPressed())
            {

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) || controls.Gameplay.Pause.IsPressed())
            {
                Time.timeScale = 1f;
                pMenu.SetActive(false);
                shooting.enabled = true;
            }

            Time.timeScale = 1f;
            pMenu.SetActive(false);
            shooting.enabled = true;
            gameIsPaused = false;
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
