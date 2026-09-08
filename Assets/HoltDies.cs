using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoltDies : MonoBehaviour
{

    public Animator anim;
    public MoveForward move;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tutorialDeath")
        {
            anim.SetTrigger("Dead");
            move.enabled = false;
        }
    }
}
