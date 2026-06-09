using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWakeUp : MonoBehaviour
{

    public MoveForward move;


    private void Start()
    {
        move = GetComponent<MoveForward>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "SpecialBullet")
        {
            move.enabled = true;
        }
    }
}
