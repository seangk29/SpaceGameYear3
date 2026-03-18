using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class PermaPlayerStats : MonoBehaviour
{
    // For stuff like max health, different to the one thats on the player object that actually updates.
    public ActivePlayerHealth activePlayerHealth;
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

    private void Update()
    {
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
