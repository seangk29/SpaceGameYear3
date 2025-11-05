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
}
