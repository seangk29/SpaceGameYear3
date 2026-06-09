using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesEnemy : MonoBehaviour
{

    Transform enemy;

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
            GameObject go1 = GameObject.FindWithTag("shootEnemy");
            GameObject go2 = GameObject.FindWithTag("spinnyShootEnemy");


            if (go != null || go1 != null || go2 != null)
            {
                enemy = go.transform;
                enemy = go1.transform;
                enemy = go2.transform;
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
