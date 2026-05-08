using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualPlayerRotate : MonoBehaviour
{

    public int directionNumber = 0;
    public int maxDirectionRight = 4;
    public int maxDirectionLeft = -4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            directionNumber = directionNumber + 1;

        }


        if (directionNumber == 1 && directionNumber < maxDirectionRight)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, -90);

            transform.rotation = rot1;
        }

        if (directionNumber == 2 && directionNumber < maxDirectionRight)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 180);

            transform.rotation = rot1;
        }

        if (directionNumber == 3 && directionNumber < maxDirectionRight)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 90);

            transform.rotation = rot1;
        }

        if (directionNumber == 4 && directionNumber == maxDirectionRight || directionNumber == 0)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 0);

            transform.rotation = rot1;
        }

        if (directionNumber >= maxDirectionRight)
        {
            directionNumber = 0;
        }


        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            directionNumber = directionNumber - 1;


        }

        if (directionNumber == -1 && directionNumber > maxDirectionLeft)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 90);

            transform.rotation = rot1;
        }

        if (directionNumber == -2 && directionNumber > maxDirectionLeft)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 180);

            transform.rotation = rot1;
        }

        if (directionNumber == -3 && directionNumber > maxDirectionLeft)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, -90);

            transform.rotation = rot1;
        }

        if (directionNumber == -4 && directionNumber == maxDirectionLeft || directionNumber == 0)
        {
            Quaternion rot1 = transform.rotation;

            rot1 = Quaternion.Euler(0, 0, 0);

            transform.rotation = rot1;
        }

        if (directionNumber <= maxDirectionLeft)
        {
            directionNumber = 0;
        }
    }
}
