using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingChoice : MonoBehaviour
{
    public void Choose()
    {
        PlayerShooting.MakingChoice = false;

        if (PlayerShooting.MakingChoice == false)
        {
            DestroyImmediate(gameObject, true);
        }
    }
}
