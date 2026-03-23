using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextAreaTP : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
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
        {
            gameObject.SetActive(true);

        }
        else { gameObject.SetActive(false); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameManager.currentLevel == 10)
            {
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
