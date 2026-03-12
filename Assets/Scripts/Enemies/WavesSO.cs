using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "New Wave", menuName = "Waves")]

public class WavesSO : ScriptableObject
{
    public string waveName;

    public GameObject wavePrefab;

    public int numOfEnemies;

    public bool selectedRecently;
}
