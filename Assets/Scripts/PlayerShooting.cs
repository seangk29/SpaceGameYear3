using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject SbulletPrefab;


    public GameObject GunPos;

    public static bool MakingChoice = false;
    
    public float fireDelay = 0.25f;
    public float SPfireDelay = 3f;
    float cooldownTimer = 0;
    float ScooldownTimer = 0;

   
    
    public PlayerMovement Special;

    PlayerControls controls;
    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.ShootStandard.performed += ctx => Shoot();
        controls.Gameplay.ShootSpecial.performed += ctx => SpecialShoot();
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    public void Start()
    {
        PlayerMovement Special = GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        Shoot();
        SpecialShoot();
        cooldownTimer -= Time.deltaTime;

        /*if (Input.GetKey(KeyCode.Mouse0) && cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }*/
    }

    public void Shoot()
    {
        // cooldownTimer -= Time.deltaTime;

       

        if (MakingChoice == false)
        {

            if (Input.GetKey(KeyCode.Mouse0) && cooldownTimer <= 0 || controls.Gameplay.ShootStandard.IsPressed() && cooldownTimer <= 0)
            {
                cooldownTimer = fireDelay;
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
            



        }

    }

    public void SpecialShoot()
    {
        ScooldownTimer -= Time.deltaTime;

        if (MakingChoice == false)
        {
           
            if (Input.GetKey(KeyCode.Mouse1) && ScooldownTimer <= 0 && Special.CanUseSpecial == true
                || controls.Gameplay.ShootSpecial.IsPressed() && ScooldownTimer <= 0 && Special.CanUseSpecial == true)
            {
                ScooldownTimer = SPfireDelay;
                Instantiate(SbulletPrefab, transform.position, transform.rotation);
            }
        }

    }
}

