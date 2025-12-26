using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameObject spreadShot;
    public GameObject ricochetShot;

    public PlayerShooting currentSpecialPos1;
    public PlayerShooting currentSpecialPos2;
    public PlayerShooting currentSpecialPos3;
    public PlayerShooting currentSpecialPos4;


    private void Start()
    {
        PlayerShooting currentSpecial = GetComponent<PlayerShooting>();
    }

    public void GetSpreadShot()
    {
        currentSpecialPos1.SbulletPrefab = spreadShot;
        currentSpecialPos2.SbulletPrefab = spreadShot;
        currentSpecialPos3.SbulletPrefab = spreadShot;
        currentSpecialPos4.SbulletPrefab = spreadShot;
    }

    public void GetRichochetShot()
    {
        currentSpecialPos1.SbulletPrefab = ricochetShot;
        currentSpecialPos2.SbulletPrefab = ricochetShot;
        currentSpecialPos3.SbulletPrefab = ricochetShot;
        currentSpecialPos4.SbulletPrefab = ricochetShot;

    }
}
