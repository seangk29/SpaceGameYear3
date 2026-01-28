using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonDestroyable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
