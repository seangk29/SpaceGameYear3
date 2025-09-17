using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public static float moveSpeed = 4f;
    public float rotationSpeed = 180f;

    public GameObject PlayerShip;
    public GameObject PlayerShipLeft;
    public GameObject PlayerShipRight;
    public GameObject PlayerShipDown;

   
    
    // Update is called once per frame
    void Update()
    {
       

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0);

        transform.Translate(movement * moveSpeed * Time.deltaTime);

     

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {

            PlayerShip.SetActive(true);
            PlayerShipLeft.SetActive(false);
            PlayerShipRight.SetActive(false);
            PlayerShipDown.SetActive(false);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {


            PlayerShip.SetActive(false);
            PlayerShipLeft.SetActive(true);
            PlayerShipRight.SetActive(false);
            PlayerShipDown.SetActive(false);



        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {


            PlayerShip.SetActive(false);
            PlayerShipLeft.SetActive(false);
            PlayerShipRight.SetActive(true);
            PlayerShipDown.SetActive(false);






        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {


            PlayerShip.SetActive(false);
            PlayerShipLeft.SetActive(false);
            PlayerShipRight.SetActive(false);
            PlayerShipDown.SetActive(true);




        }



     

    }

   






}

    /*private void RotatingShip()
    {
        Quaternion rotation = transform.rotation;
        float z = rotation.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        rotation = Quaternion.Euler(0, 0, z);

        transform.rotation = rotation;

     
    }*/



