using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Richcet : MonoBehaviour
{

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(1, 1).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the normal vector of the surface the object collided with
        Vector2 surfaceNormal = collision.contacts[0].normal;

        // Calculate the reflected direction vector
        direction = Vector2.Reflect(direction, surfaceNormal);
    }

}
