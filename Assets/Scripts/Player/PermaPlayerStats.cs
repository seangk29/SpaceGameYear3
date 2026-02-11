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
    public PlayerData playerData;

    public int health;
    public int maxHealth;

    public int shield;
    public int maxShield;

    public int speed;
    public int maxSpeed;

    public string activeSpecial;
    public bool canUseSpecial;

    private void Update()
    {
        if (activePlayerHealth == null)
        {
            activePlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<ActivePlayerHealth>();
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        }
        else
            return;
    }

    public void MaxHealthUpgrade(int value)
    {
        activePlayerHealth.health = activePlayerHealth.health + value;
        maxHealth = maxHealth + value;
        gameObject.GetComponentInChildren<ActivePlayerHealth>();
        Debug.Log("shouldve upgraded health");
    }

    public void MaxShieldUpgrade(int value)
    {
        activePlayerHealth.shieldHealth = activePlayerHealth.shieldHealth + value;
        maxShield = maxShield + value;
        Debug.Log("Shield Upgraded");

    }

    public void heal(int value)
    {
        activePlayerHealth.health= activePlayerHealth.health + value;
        Debug.Log("healed");
    }

    public void MaxSpeedUpgrade(int value)
    { 
        playerMovement.moveSpeed = playerMovement.moveSpeed + value;
        maxSpeed = maxSpeed + value;
        gameObject.GetComponentInChildren<PlayerMovement>();
        Debug.Log("Speed upgraded");
    }

    public void spreadUnlock()
    {
        playerData.GetSpreadShot();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "Spread";
        Debug.Log("Spread Shot Unlocked");
    }

    public void ricochetUnlock()
    {
        playerData.GetRichochetShot();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "Richochet";
        Debug.Log("Richochet Shot Unlocked");
    }

    public void explodeUnlock()
    {
        playerData.GetExplodeShot();
        playerMovement.CanUseSpecial = true;
        canUseSpecial = true;
        activeSpecial = "Explode";
        Debug.Log("Explode Shot Unlocked");
    }
}
