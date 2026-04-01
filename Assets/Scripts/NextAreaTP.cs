using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextAreaTP : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject OnScreen;
    public GameObject OffScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }

        gameManager = GameObject.FindGameObjectWithTag("GameMg").GetComponent<GameManager>();
        

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
        if (state == GameManager.GameState.NextArea)
        //if (gameManager.currentState == GameManager.GameState.NextArea)
        {
            Debug.Log("on screen");
            gameObject.transform.position = OnScreen.transform.position;
        }
        else { gameObject.transform.position = OffScreen.transform.position;
            Debug.Log("off screen");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3" || collision.gameObject.tag == "Player4" )
        {
            Debug.Log("player collided");

            if (gameManager.currentLevel == 10)
            {
                Debug.Log("it would load boss here");
                SceneManager.LoadScene("BOSS1");
            }
            else
            {
                Debug.Log("it would load here");
                SceneManager.LoadScene("NoPDGameplay");
            }
       }
    }
}
