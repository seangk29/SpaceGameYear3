using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float moveSpeed = 5f;

    public bool movingForward;
    public bool movingBackwards;
    public bool movingLeft;
    public bool movingRight;

    // Update is called once per frame
    void Update()
    {
        if (movingForward)
        {
            Vector3 pos = transform.position;

            Vector3 velocity = new Vector3(0, moveSpeed * Time.deltaTime, 0);

            pos += transform.rotation * velocity;

            transform.position = pos;
        }

        if (movingBackwards)
        {
            Vector3 pos = transform.position;

            Vector3 velocity = new Vector3(0, -moveSpeed * Time.deltaTime, 0);

            pos += transform.rotation * velocity;

            transform.position = pos;
        }
        if (movingRight)
        {
            Vector3 pos = transform.position;

            Vector3 velocity = new Vector3(moveSpeed * Time.deltaTime, 0, 0);

            pos += transform.rotation * velocity;

            transform.position = pos;
        }
        if (movingLeft)
        {
            Vector3 pos = transform.position;

            Vector3 velocity = new Vector3(-moveSpeed * Time.deltaTime, 0, 0);

            pos += transform.rotation * velocity;

            transform.position = pos;
        }


    }
}
