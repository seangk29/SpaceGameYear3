using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class NPC : MonoBehaviour, Interactable
{
    [SerializeField] GameObject interOBJ;

    private Transform PlayerTrans;


    private const float Distance = 2f;

  private void Start()
    {
        //This finds the players location in the scene.
        PlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        //This is used to let the game have a set distance required for the player talk to the NPC.


        if (Input.GetKeyDown(KeyCode.E) && IsInteractableDistance())
        {
            interact();
        }

        if (interOBJ.gameObject.activeSelf && !IsInteractableDistance())
        {
            interOBJ.gameObject.SetActive(false);
        }

        if (!interOBJ.gameObject.activeSelf && IsInteractableDistance())
        {
            interOBJ.gameObject.SetActive(true);
        }

    }

    public abstract void interact();
   
    private bool IsInteractableDistance()
    {
        //This finds the interact distance.
        if (Vector3.Distance(PlayerTrans.position, transform.position) < Distance)
        {
            return true;
        }
        else 
        {
           return false;
        }
    }


}
