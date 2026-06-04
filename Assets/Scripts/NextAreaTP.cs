using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextAreaTP : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject OnScreen;
    public GameObject OffScreen;
    public GameObject interact;

    public bool canTeleport;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }

        gameManager = GameObject.FindGameObjectWithTag("GameMg").GetComponent<GameManager>();

        canTeleport = false;
    }

    private void Update()
    {
        /*if (canTeleport && Input.GetKey(KeyCode.E)
            || canTeleport && Input.GetKey(KeyCode.Joystick1Button3))
        {

            if (gameManager.currentState == GameManager.GameState.BossDefeated)
            {
                // load ending scene
                SceneManager.LoadSceneAsync("Ending");
            }
            else
            {
                if (gameManager.currentLevel == 10)
                {
                    Debug.Log("it would load boss here");
                    SceneManager.LoadSceneAsync("BOSS 1");
                }
                else if (gameManager.currentLevel == 0)
                {
                    Debug.Log("start gameplay");
                    SceneManager.LoadSceneAsync("Start Gameplay");
                }
                else
                {
                    Debug.Log("it would load here");
                    SceneManager.LoadSceneAsync("NoPDGameplay");
                }
            }



            Debug.Log("player collided");


        }*/
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
        if (state == GameManager.GameState.NextArea || state == GameManager.GameState.BossDefeated)
        //if (gameManager.currentState == GameManager.GameState.NextArea)
        {
           // Debug.Log("on screen");
            gameObject.transform.position = OnScreen.transform.position;
        }
        else { gameObject.transform.position = OffScreen.transform.position;
            //Debug.Log("off screen");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player1"))
        {

            if (gameManager.currentState == GameManager.GameState.BossDefeated)
            {
                // load ending scene
                SceneManager.LoadSceneAsync("Ending");
            }
            else
            {
                if (gameManager.currentLevel == 10)
                {
                   // Debug.Log("it would load boss here");
                    SceneManager.LoadSceneAsync("BOSS 1");
                }
                else if (gameManager.currentLevel == 0)
                {
                   // Debug.Log("start gameplay");
                    SceneManager.LoadSceneAsync("Start Gameplay");
                }
                else if (gameManager.currentLevel > 0 && gameManager.currentLevel <= 3)
                {
                   // Debug.Log("it would load here");
                    SceneManager.LoadSceneAsync("NoPDGameplay");
                }

                else if (gameManager.currentLevel > 3 && gameManager.currentLevel <= 6)
                {
                    // Debug.Log("it would load here");
                    SceneManager.LoadSceneAsync("Action 2");
                }
            }



           // Debug.Log("player collided");


        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        interact.SetActive(false);
        canTeleport = false;
    }
}
