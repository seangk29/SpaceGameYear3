using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

//ok hi im gonna explain how this works

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]


// theres a folder in assets called upgrades that has a bunch of scriptable objects
// each scriptable object has each of these variables it can change depending on the upgrade
public class CardSO : ScriptableObject
{
    // self explanatory
    public Sprite cardImage;

    // text that shows up like "+1 HP" or "+1 damage" etc
    public string cardText;

    // what the upgrade actually does
    public CardEffect effectType;

    public CardSO effectString;

    // how much each effect changes so we can do "+1 hp" and "+2 shield" with the same script
    public int effectValue;

    // this is for if the upgrade should only be selected one time
    // so like hp can show up a bunch but you can only get one unlock spread shot
    public bool isUnique;

    public int unlockLevel;
}


// including the actual effect that the upgrade has
public enum CardEffect
{
    HpIncrease,
    ShieldIncrease,
    ShieldRegenIncrease,
    SpeedIncrease
}
