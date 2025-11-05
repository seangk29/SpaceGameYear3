using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float speedIndicator = 4f;
 //   public float rotationSpeed = 360f;

    public bool Dodging;
    public float cooldownDodge = 0f;
    public float Dtimer = 0f;
    public float dodgeSpeed = 15f;

    public bool CanUseSpecial = false;

    public GameObject PlayerShip;
    public GameObject PlayerShipLeft;
    public GameObject PlayerShipRight;
    public GameObject PlayerShipDown;

    public void SpeedUpgrade()
    {
       moveSpeed = moveSpeed + 1f;
       speedIndicator = speedIndicator + 1f;
    }
    public void EnableSpecial()
    {
        CanUseSpecial = true;
        Debug.Log("should be able to use special bullets now");
    }

    private void Start()
    {
        if (gameObject.tag == "Player")
        {

          //  CanUseSpecial = false;
          //  moveSpeed = 4f;
          //  speedIndicator = 4f;

        }
       
    }

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

            moveSpeed = dodgeSpeed;


        }

        if (cooldownDodge >= 0.25)
        {

            moveSpeed = speedIndicator;
            cooldownDodge = 0;
            Dodging = false;
        }


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



       /* if (Input.GetKey(KeyCode.LeftShift))
        {
            RotatingShip();
        }*/

    }



   /* private void RotatingShip()
    {
        Quaternion rotation = transform.rotation;
        float z = rotation.eulerAngles.z;
        z -=  transform.position.x * rotationSpeed * Time.deltaTime;
        rotation = Quaternion.Euler(0, 0, 90);

        transform.rotation = rotation;


    }*/




}

  



