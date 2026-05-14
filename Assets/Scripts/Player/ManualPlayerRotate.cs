using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualPlayerRotate : MonoBehaviour
{

    public int directionNumber = 0;
    public int maxDirectionRight = 4;
    public int maxDirectionLeft = -4;

    public PlayerMovement rotate;


    // Start is called before the first frame update
    void Start()
    {
        rotate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Clockwise Rotation

        if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D))
        {
            directionNumber = directionNumber + 1;

        }


        if (directionNumber == 1 && directionNumber < maxDirectionRight)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, -90);

            transform.rotation = rot1;

            rotate.ShipRight = true;

            rotate.ShipLeft = false;
            rotate.ShipUp = false;
            rotate.ShipDown = false;
        }

        if (directionNumber == 2 && directionNumber < maxDirectionRight)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 180);

            transform.rotation = rot1;

            rotate.ShipDown = true;

            rotate.ShipLeft = false;
            rotate.ShipUp = false;
            rotate.ShipRight = false;
        }

        if (directionNumber == 3 && directionNumber < maxDirectionRight)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 90);

            transform.rotation = rot1;

            rotate.ShipLeft = true;

            rotate.ShipRight = false;
            rotate.ShipUp = false;
            rotate.ShipDown = false;
        }

        if (directionNumber == 4 && directionNumber == maxDirectionRight || directionNumber == 0)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 0);

            transform.rotation = rot1;

            rotate.ShipUp = true;

            rotate.ShipLeft = false;
            rotate.ShipRight = false;
            rotate.ShipDown = false;
        }

        if (directionNumber >= maxDirectionRight)
        {
            directionNumber = 0;
        }

        //Counter-Clockwise Rotation

        if (Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A))
        {
            directionNumber = directionNumber - 1;


        }

        if (directionNumber == -1 && directionNumber > maxDirectionLeft)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 90);

            transform.rotation = rot1;

            rotate.ShipLeft = true;

            rotate.ShipDown = false;
            rotate.ShipUp = false;
            rotate.ShipRight = false;

        }

        if (directionNumber == -2 && directionNumber > maxDirectionLeft)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 180);

            transform.rotation = rot1;

            rotate.ShipDown = true;

            rotate.ShipLeft = false;
            rotate.ShipUp = false;
            rotate.ShipRight = false;
        }

        if (directionNumber == -3 && directionNumber > maxDirectionLeft)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, -90);

            transform.rotation = rot1;

            rotate.ShipRight = true;

            rotate.ShipDown = false;
            rotate.ShipUp = false;
            rotate.ShipLeft = false;


        }

        if (directionNumber == -4 && directionNumber == maxDirectionLeft || directionNumber == 0)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 0);

            transform.rotation = rot1;

            rotate.ShipUp = true;

            rotate.ShipLeft = false;
            rotate.ShipRight = false;
            rotate.ShipDown = false;
        }

        if (directionNumber <= maxDirectionLeft)
        {
            directionNumber = 0;
        }
    }
}
