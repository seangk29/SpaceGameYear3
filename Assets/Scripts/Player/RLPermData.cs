using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RLPermData : MonoBehaviour
{
    // essentially the same as RLTempData, but its the base stats + shop buffs that stay between runs.

    public PermaPlayerStats rlTempData;
    public PlayerMovement playerMovement;
    public SpecialShotHandler specialShotHandler;

    public int health;
    public int maxHealth;

    public int shield;
    public int maxShield;

    public int regenShieldTimer;
    public int baseRegenShieldTimer;

    public int speed;
    public int maxSpeed;

    public string activeSpecial;
    public bool canUseSpecial;

    public int damage;
    public int specialDamage;
    public int spBulletHealth;
    Scene scene;


    //all this enable disable scene load part does is check if its the main menu
    //or the quit scene
    //and deletes all player data for that run
    //i mean it SHOULD do that i hope it does
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        /*if (scene.name == "Main Menu")
            Destroy(gameObject);*/
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // the rest should all be self explanatory
    // its just functions that get called to upgrade stats
    private void Update()
    {
        if (rlTempData == null)
        {
            rlTempData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PermaPlayerStats>();
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

    public void MaxHealthUpgrade(int value)
    {
        rlTempData.health = rlTempData.health + value;
        maxHealth = maxHealth + value;
        gameObject.GetComponentInChildren<ActivePlayerHealth>();
        Debug.Log("Max Health Upgraded");
    }

    public void MaxShieldUpgrade(int value)
    {
        rlTempData.shield = rlTempData.shield + value;
        maxShield = maxShield + value;
        Debug.Log("Shield Upgraded");

    }

    public void ShieldRegenUpgrade(int value)
    {
        rlTempData.baseRegenShieldTimer = rlTempData.baseRegenShieldTimer - value;
        regenShieldTimer = regenShieldTimer - value;
        Debug.Log("Shield Regen Upgraded");
    }

    public void heal(int value)
    {
        rlTempData.health = rlTempData.health + value;
        Debug.Log("Healed");
    }

    public void MaxSpeedUpgrade(int value)
    {
        playerMovement.moveSpeed = playerMovement.moveSpeed + value;
        maxSpeed = maxSpeed + value;
        gameObject.GetComponentInChildren<PlayerMovement>();
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


    public void spreadUnlock()
    {
        specialShotHandler.GetSpreadShot();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "Spread";
        Debug.Log("Spread Shot Unlocked");
    }

    public void ricochetUnlock()
    {
        specialShotHandler.GetRichochetShot();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "Richochet";
        Debug.Log("Richochet Shot Unlocked");
    }

    public void explodeUnlock()
    {
        specialShotHandler.GetExplodeShot();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "Explode";
        Debug.Log("Explode Shot Unlocked");
    }
}
