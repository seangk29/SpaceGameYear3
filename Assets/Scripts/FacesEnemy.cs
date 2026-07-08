using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesEnemy : MonoBehaviour
{

   public Transform enemy;

    public float rotSpeed = 90f;

    



    // Update is called once per frame
    void Update()
    {
        enemyFollow();
       
    }

    void enemyFollow()
    {
        if (enemy == null)
        {
            GameObject go = GameObject.FindWithTag("Enemy");
            

            if (go != null )
            {
                enemy = go.transform;
                
            }
        }

        if (enemy == null)
        {
            GameObject go = GameObject.FindWithTag("shootEnemy");


            if (go != null)
            {
                enemy = go.transform;

            }
        }

        if(enemy == null)
        {
            GameObject go = GameObject.FindWithTag("spinnyShootEnemy");


            if (go != null)
            {
                enemy = go.transform;

            }
        }

        if (enemy == null)
        {
            return;
        }

        Vector3 dir = enemy.position - transform.position;
        dir.Normalize();

       

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
       

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        
    }


    
}
