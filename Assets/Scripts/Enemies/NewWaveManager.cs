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
    public int maxWaves;

    // Currently randomized cards go here
    GameObject waveOne, waveTwo, waveThree;

    List<WavesSO> alreadySelectedWaves = new List<WavesSO>();

    public static NewWaveManager Instance;

    private void Awake()
    {
        Instance = this;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }
    }

    private void FixedUpdate()
    {

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }

        if (currentWave.numOfEnemies >= enemiesKilled)
        {
            waveNumber += 1;
            Debug.Log("yay");

            if (waveNumber >= maxWaves)
            {
                Debug.Log("win");
            }
        }

    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged -= HandleGameStateChanged;
        }
    }

    private void HandleGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.WaveGenerate)
        {
            RandomizeNewWaves();
        }
    }
    public void RandomizeNewWaves()
    {
        if (waveOne != null) Destroy(waveOne);
        if (waveTwo != null) Destroy(waveTwo);
        if (waveThree != null) Destroy(waveThree);

        List<WavesSO> randomizedWaves = new List<WavesSO>();
        List<WavesSO> availableWaves = new List<WavesSO>(Waves);

        while (randomizedWaves.Count < 3)
        {
            WavesSO randomWave = availableWaves[Random.Range(0, availableWaves.Count)];
            if (!randomizedWaves.Contains(randomWave))
            {
                if (randomWave.selectedRecently != true)
                {
                    randomWave.selectedRecently = true;
                    randomizedWaves.Add(randomWave);
                }
                else
                { 
                    // should loop back to the start of while? hopefully
                    return;
                }
            }
        }

        waveNumber = 0;

        currentWave = randomizedWaves[waveNumber];
        //waveOne = InstantiateCard(randomizedWaves[0].wavePrefab, wavePosition);
    }

    GameObject InstantiateCard(GameObject wavePrefab, Transform position)
    {
        GameObject waveGO = Instantiate(wavePrefab, position.position, Quaternion.identity, position);
        //Card card = waveGO.GetComponent<Card>();
        //card.Setup(wavesSO);
        return waveGO;
    }
}
