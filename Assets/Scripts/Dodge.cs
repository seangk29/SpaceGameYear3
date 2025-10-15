using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    


    public bool Dodging;
    public float cooldownDodge = 0f;
    public float Dtimer = 0f;



    // Update is called once per frame
    void Update()
    {
       
        Dtimer -= Time.deltaTime;

        if (Dodging)
        {
            cooldownDodge += Time.deltaTime;
        }
     

        if (Input.GetKey(KeyCode.Space) && Dtimer <= 0)
        {
            Dodging = true;

            Dtimer = 2f;
 

        }

        if (cooldownDodge >= 0.01)
        {
            
            //moveSpeed = 15;


        }

        if (cooldownDodge >= 0.25)
        {

           // moveSpeed = 4;
            cooldownDodge = 0;
            Dodging = false;
        }
        


    }
}
        
        