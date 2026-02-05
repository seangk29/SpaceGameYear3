using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class PermaPlayerStats : MonoBehaviour
{
    // For stuff like max health, different to the one thats on the player object that actually updates.
    public ActivePlayerHealth activePlayerHealth;

    public int health;
    public int maxHealth;

    public int shield;
    public int maxShield;

    private void Update()
    {
        if (activePlayerHealth != null)
        {
            activePlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<ActivePlayerHealth>();
        }
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
        Debug.Log("Choice");

    }

    public void heal(int value)
    {
        activePlayerHealth.health= activePlayerHealth.health + value;
    }

}
