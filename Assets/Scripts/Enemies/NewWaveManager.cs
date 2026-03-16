using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NewWaveManager : MonoBehaviour
{
    //[SerializeField] GameObject wavePrefab;

    [SerializeField] List<WavesSO> Waves;

    [SerializeField] Transform wavePosition;

    public WavesSO currentWave;
    public int enemiesKilled;
    public int waveNumber;
    public int oldWaveNumber;
    public int maxWaves;

    // Currently randomized cards go here
    GameObject spawnWave;

    List<WavesSO> alreadySelectedWaves = new List<WavesSO>();

    public List<WavesSO> randomizedWaves = new List<WavesSO>();

    public static NewWaveManager Instance;

    private void Awake()
    {
        Instance = this;

        /*if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }*/

        waveNumber = 0;
        oldWaveNumber = 0;
    }

    private void FixedUpdate()
    {

        /*if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }*/

        if (currentWave != null)
        {
            if (currentWave.numOfEnemies <= enemiesKilled)
            {
                waveNumber += 1;
                enemiesKilled = 0;
                Debug.Log("yay");

                if (waveNumber >= maxWaves)
                {
                    GameManager.Instance.changeState(GameManager.GameState.CardSelection);
                    Debug.Log("win");
                }
            }
        }

        if (randomizedWaves.Count == 3 && oldWaveNumber < waveNumber)
        {
            oldWaveNumber = waveNumber;
            currentWave = randomizedWaves[waveNumber];
            spawnWave = InstantiateWave(randomizedWaves[waveNumber].wavePrefab, wavePosition);
        }
    }

    /*private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged -= HandleGameStateChanged;
        }
    }*/

    /*private void HandleGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.WaveGenerate)
        {
            RandomizeNewWaves();
        }
    }*/

    public void RandomizeNewWaves()
    {
        /*if (waveOne != null) Destroy(waveOne);
        if (waveTwo != null) Destroy(waveTwo);
        if (waveThree != null) Destroy(waveThree);*/

        //List<WavesSO> randomizedWaves = new List<WavesSO>();
        List<WavesSO> availableWaves = new List<WavesSO>(Waves);

        while (randomizedWaves.Count < 3)
        {
            WavesSO randomWave = availableWaves[Random.Range(0, maxWaves)];
            if (!randomizedWaves.Contains(randomWave))
            {
                if (randomWave.selectedRecently != true)
                {
                    randomizedWaves.Add(randomWave);
                    randomWave.selectedRecently = true;
                }
                else
                { 
                    // should loop back to the start of while? hopefully
                    randomWave.selectedRecently = false;
                    return;
                }
            }
        }

        while (randomizedWaves.Count > maxWaves)
        {
            randomizedWaves.Remove(randomizedWaves[maxWaves + 1]);
        }

        while (randomizedWaves.Count == 3 && oldWaveNumber <= waveNumber)
        {
            oldWaveNumber = waveNumber;
            currentWave = randomizedWaves[waveNumber];
            spawnWave = InstantiateWave(randomizedWaves[waveNumber].wavePrefab, wavePosition);
        }

        /*waveNumber = 0;

        currentWave = randomizedWaves[waveNumber];
        spawnWave = InstantiateCard(randomizedWaves[waveNumber].wavePrefab, wavePosition);*/
    }

    GameObject InstantiateWave(GameObject wavePrefab, Transform position)
    {
        GameObject waveGO = Instantiate(wavePrefab, position.position, Quaternion.identity, position);
        GameManager.Instance.changeState(GameManager.GameState.Playing);
        return waveGO;
    }
}
