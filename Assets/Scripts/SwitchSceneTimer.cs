using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneTimer : MonoBehaviour
{
    public SceneChanger changer;


    public float timer = 0;


    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 80)
        {
           changer.NextLevel();
        }
    }
}
