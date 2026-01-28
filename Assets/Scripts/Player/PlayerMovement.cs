using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

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

    public GameObject afterImagePrefab;
    public bool emitting;
    public float interval = 0.2f;
    public bool ShipUp;
    public bool ShipDown;
    public bool ShipLeft;
    public bool ShipRight;

    public GameObject SpriteUp;
    public GameObject SpriteDown;
    public GameObject SpriteLeft;
    public GameObject SpriteRight;

    
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
        
       
    }

    IEnumerator EmitAfterImages()
    {
        while (emitting)
        {
            SpawnAfterImage();
            yield return new WaitForSecondsRealtime(0.075f);
        
            

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

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) 
            || controls.Gameplay.ChangeDirection.IsPressed() && controls.Gameplay.ChangeUp.IsPressed())
         {

             PlayerShip.SetActive(true);
             PlayerShipLeft.SetActive(false);
             PlayerShipRight.SetActive(false);
             PlayerShipDown.SetActive(false);

            ShipUp = true;
            ShipDown = false;
            ShipLeft = false;
            ShipRight = false;
        }
         if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) 
            || controls.Gameplay.ChangeDirection.IsPressed() && controls.Gameplay.ChangeLeft.IsPressed())
         {


             PlayerShip.SetActive(false);
             PlayerShipLeft.SetActive(true);
             PlayerShipRight.SetActive(false);
             PlayerShipDown.SetActive(false);

            ShipUp = false;
            ShipDown = false;
            ShipLeft = true;
            ShipRight = false;

        }
         if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) 
            || controls.Gameplay.ChangeDirection.IsPressed() && controls.Gameplay.ChangeRight.IsPressed())
         {


             PlayerShip.SetActive(false);
             PlayerShipLeft.SetActive(false);
             PlayerShipRight.SetActive(true);
             PlayerShipDown.SetActive(false);


            ShipUp = false;
            ShipDown = false;
            ShipLeft = false;
            ShipRight = true;



        }
         if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) 
            || controls.Gameplay.ChangeDirection.IsPressed() && controls.Gameplay.ChangeDown.IsPressed())
         {


             PlayerShip.SetActive(false);
             PlayerShipLeft.SetActive(false);
             PlayerShipRight.SetActive(false);
             PlayerShipDown.SetActive(true);

            ShipUp = false;
            ShipDown = true;
            ShipLeft = false;
            ShipRight = false;


        }



       /* if (Input.GetKey(KeyCode.E))
        {
            RotatingShip();
        }*/

    }

    


    void SpawnAfterImage()
    {
        if (ShipUp)
        {
            afterImagePrefab = SpriteUp;
           
        }

        if (ShipDown)
        {
            afterImagePrefab = SpriteDown;
           
        }

        if (ShipLeft)
        {
            afterImagePrefab = SpriteLeft;
        }
            
        if (ShipRight)
        {
            afterImagePrefab = SpriteRight;

        }

        GameObject renderer = Instantiate(afterImagePrefab, transform.position, transform.rotation);
        renderer.transform.localScale = transform.localScale;
    }
    public void Dash()
    {
        if (Input.GetKey(KeyCode.Space) && Dtimer <= 0 || controls.Gameplay.Dash.IsPressed() && Dtimer <= 0)
        {
            Dodging = true;
            emitting = true;

            Dtimer = 2f;
            
            StartCoroutine(EmitAfterImages());
          

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
            emitting = false;

          
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

  



