using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class PermaPlayerStats : MonoBehaviour
{
    // For stuff like max health, different to the one thats on the player object that actually updates.

    public ActivePlayerHealth activePlayerHealth;
    public PlayerMovement playerMovement;
    public SpecialShotHandler specialShotHandler;
    public RLPermData rlPermData;

    public int health;
    public int maxHealth;

    public int shield;
    public int maxShield;

    public int regenShieldTimer;
    public int baseRegenShieldTimer;

    public float speed;
    public float maxSpeed;

    public string activeSpecial;
    public bool canUseSpecial;
  
    public int damage;
    public int specialDamage;
    public int spBulletHealth;
    Scene scene;

    public bool checkObject = false;
    public bool activeSpin = false;
    public bool activeGunBot = false;

    //all this enable disable scene load part does is check if its the main menu
    //or the quit scene
    //and deletes all player data for that run
    //i mean it SHOULD do that i hope it does
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Start Gameplay")
        {
            resetStats();
            checkObject = false;
        }

        if (scene.name == "NoPDGameplay" || scene.name == "BOSS 1" || scene.name == "Hub" || scene.name == "PostGameplayHub")
        {
            checkObject = true;
        }
        else
            checkObject = false;
    }

    private void Update()
    {
        /*if (checkObject)
        {*/
            if (activePlayerHealth == null)
            {
                activePlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<ActivePlayerHealth>();
            }
            else
                return;

            if (playerMovement == null)
            {
                playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            }
            else
                return;

            if (specialShotHandler == null)
            {
                specialShotHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<SpecialShotHandler>();
            }
            else
                return;

 
        
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // the rest should all be self explanatory
    // its just functions that get called to upgrade stats

    public void MaxHealthUpgrade(int value)
    {
        activePlayerHealth.health = activePlayerHealth.health + value;
        maxHealth = maxHealth + value;
        gameObject.GetComponentInChildren<ActivePlayerHealth>();
        Debug.Log("Max Health Upgraded");
    }

    public void MaxShieldUpgrade(int value)
    {
        activePlayerHealth.shieldHealth = activePlayerHealth.shieldHealth + value;
        maxShield = maxShield + value;
        Debug.Log("Shield Upgraded");

    }

    public void ShieldRegenUpgrade(int value)
    {
        activePlayerHealth.regenShieldsTimer = activePlayerHealth.regenShieldsTimer - value;
        regenShieldTimer = regenShieldTimer - value;
        Debug.Log("Shield Regen Upgraded");
    }

    public void heal(int value)
    {
        activePlayerHealth.health= activePlayerHealth.health + value;
        Debug.Log("Healed");
    }

    public void MaxSpeedUpgrade(float value)
    { 
        playerMovement.moveSpeed = playerMovement.moveSpeed + value;
        speed = speed + value;
        maxSpeed = maxSpeed + value;
        gameObject.GetComponent<PlayerMovement>();
        Debug.Log("Speed upgraded");
    }

    public void damageUpgrade(int value)
    {
        damage += value;
        Debug.Log("Standard Damage Upgraded");
    }

    public void spDmgUpgrade(int value)
    { 
        specialDamage += value;
        Debug.Log("Special Damage Upgraded");
    }

    public void spBulletHPUpgrade(int value)
    { 
        spBulletHealth += value;
        Debug.Log("Special Bullet HP Upgraded");
    }


    public void spreadUnlock(int value)
    {
        specialShotHandler.GetSpreadShot();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "Spread";
        specialDamage += value;
        //Debug.Log("Spread Shot Unlocked");
    }


    public void spreadUnlockUpgraded1(int value)
    {
        specialShotHandler.GetSpreadShotUpgraded1();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "SpreadUpgraded1";
        specialDamage += value;
      //  Debug.Log("Spread Shot Unlocked");
    }

    public void ricochetUnlock(int value)
    {
        specialShotHandler.GetRicochetShot();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "Ricochet";
        specialDamage += value;
        spBulletHealth += value;
       // Debug.Log("Ricochet Shot Unlocked");
    }

    public void ricochetUnlockUpgraded1(int value)
    {
        specialShotHandler.GetRicochetShotUpgraded1();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "RicochetUpgraded1";
        specialDamage += value;
        spBulletHealth += value;
        // Debug.Log("Ricochet Shot Unlocked");
    }



    public void explodeUnlock(int value)
    {
        specialShotHandler.GetExplodeShot();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "Explode";
        specialDamage += value;
       // Debug.Log("Explode Shot Unlocked");
    }

    public void explodeUnlockUpgraded1(int value)
    {
        specialShotHandler.GetExplodeShotUpgraded1();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "ExplodeUpgraded1";
        specialDamage += value;
        // Debug.Log("Explode Shot Unlocked");
    }

    public void spinUnlock()
    {
       
        specialShotHandler.getSpinShot();
        activeSpin = true;
       // playerMovement.CanUseSpecial = true;
       // canUseSpecial = true;
       // activeSpecial = "Spin";
    }

    public void GunBot()
    {
        specialShotHandler.getGunBot();
        activeGunBot = true;
    }

    public void resetStats()
    { 
        rlPermData = GameObject.FindGameObjectWithTag("RLPermData").GetComponent<RLPermData>();
        maxHealth = rlPermData.maxHealth;
        maxShield = rlPermData.maxShield;
        baseRegenShieldTimer = rlPermData.baseRegenShieldTimer;
        maxSpeed = rlPermData.maxSpeed;
        playerMovement.maxSpeed = rlPermData.maxSpeed;
        playerMovement.moveSpeed = rlPermData.maxSpeed;
        damage = rlPermData.damage;
        specialDamage = rlPermData.specialDamage;
        spBulletHealth = rlPermData.spBulletHealth;
    }
}
