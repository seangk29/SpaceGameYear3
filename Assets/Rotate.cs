using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 360f;

 
 

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            RotatingShip();
            
        }

        
    }


  
    private void RotatingShip()
    {
        Quaternion rotation = transform.rotation;
        float z = rotation.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        rotation = Quaternion.Euler(0, 0, z);

        transform.rotation = rotation;

        


    }
}
