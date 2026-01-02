using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float maxSpeed = 4f;
    public float speedIndicator = 4f;
    public float rotationSpeed = 360f;

    public bool Dodging;
    public float cooldownDodge = 0f;
    public float Dtimer = 0f;
    public float dodgeSpeed = 15f;

    public bool CanUseSpecial = false;

    public GameObject PlayerShip;
    public GameObject PlayerShipLeft;
    public GameObject PlayerShipRight;
    public GameObject PlayerShipDown;

    float shipBoundaryRadius = 0.25f;

    PlayerControls controls;
    
    public void SpeedUpgrade()
    {
       moveSpeed = moveSpeed + 0.2f;
        moveSpeed = maxSpeed + 0.2f;
       speedIndicator = speedIndicator + 1f;
    }
    public void EnableSpecial()
    {
        CanUseSpecial = true;
        Debug.Log("should be able to use special bullets now");
    }


    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => MovePlayer();
        controls.Gameplay.Dash.performed += ctx => Dash();
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
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
        MovePlayer();
        Dash();

        Dtimer -= Time.deltaTime;

        if (Dodging)
        {
            cooldownDodge += Time.deltaTime;
        }


        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

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



       /* if (Input.GetKey(KeyCode.E))
        {
            RotatingShip();
        }*/

    }

    public void Dash()
    {
        if (Input.GetKey(KeyCode.Space) && Dtimer <= 0 || controls.Gameplay.Dash.IsPressed() && Dtimer <= 0)
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

            moveSpeed = maxSpeed;
            cooldownDodge = 0;
            Dodging = false;
        }
    }
    public void MovePlayer()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 
                           Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime, 0);

        pos += velocity;

        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize - shipBoundaryRadius;
        }

        if (pos.y + shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + shipBoundaryRadius > widthOrtho)
        {
            pos.x = -widthOrtho - shipBoundaryRadius;
        }

        if (pos.x + shipBoundaryRadius < -widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }

        transform.position = pos;
    }
   /* private void RotatingShip()
    {
        Quaternion rotation = transform.rotation;
        float z = rotation.eulerAngles.z;
        z -=  transform.position.x * rotationSpeed * Time.deltaTime;
        rotation = Quaternion.Euler(0, 0, z);

        transform.rotation = rotation;


    }*/




}

  



