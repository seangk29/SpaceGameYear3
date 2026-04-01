using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


[CreateAssetMenu(menuName = "Shop Texts/New Upgrade")]

public class ShopText : ScriptableObject

{
    public string conTxt;


    [TextArea(5, 10)]
    public string upgradeTxt;
}
