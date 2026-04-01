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

    GameObject spawnWave;

    List<WavesSO> alreadySelectedWaves = new List<WavesSO>();

    public List<WavesSO> finalizedWaves = new List<WavesSO>();

    public static NewWaveManager Instance;

    private void Awake()
    {
        Instance = this;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }
    }

    private void Start()
    {
        waveNumber = 0;
        oldWaveNumber = 0;
    }

    private void FixedUpdate()
    {

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged += HandleGameStateChanged;
        }

        // if the wave actually exists
        if (currentWave != null)
        {
            // if youve killed all enemies in the wave
            // change current wave number to the next one
            // reset enemies killed in that wave
            if (currentWave.numOfEnemies <= enemiesKilled)
            {
                waveNumber += 1;
                enemiesKilled = 0;
                currentWave = null;
                spawningWave();
                Debug.Log("yay");

                // if youve cleared all the waves then give upgrade selection
                if (waveNumber == maxWaves)
                {
                    GameManager.Instance.changeState(GameManager.GameState.CardSelection);
                    Debug.Log("win");
                }
            }
        }
        
        /*if (randomizedWaves.Count == 3 && oldWaveNumber < waveNumber)
        {
            oldWaveNumber = waveNumber;
            currentWave = randomizedWaves[waveNumber];
            spawnWave = InstantiateWave(randomizedWaves[waveNumber].wavePrefab, wavePosition);
        }*/
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
            waveNumber = 0;
            oldWaveNumber = 0;
            RandomizeNewWaves();
        }
    }

    public void RandomizeNewWaves()
    {
        // dont think this thing does much
        /*if (waveOne != null) Destroy(waveOne);
        if (waveTwo != null) Destroy(waveTwo);
        if (waveThree != null) Destroy(waveThree);*/

        List<WavesSO> randomizedWaves = new List<WavesSO>();
        List<WavesSO> availableWaves = new List<WavesSO>(Waves);


        // randomising waves and putting them into the randomised list
        while (randomizedWaves.Count < maxWaves)
        {
            WavesSO randomWave = availableWaves[Random.Range(0, availableWaves.Count)];
            if (!randomizedWaves.Contains(randomWave))
            {
                // this whole selected recently thing confuses me like it edits the
                // so's even after the debugging is over
                // i think it works. this was just kinda to stop back to back same waves.
                if (randomWave.selectedRecently != true)
                {
                    randomizedWaves.Add(randomWave);
                    //randomWave.selectedRecently = true;
                }
                else
                { 
                    // should loop back to the start of while? hopefully
                    //randomWave.selectedRecently = false;
                    return;
                }
            }
        }

        // i dont think this actually does anything but also it doesnt break anything soooo if it aint broke dont fix it yknow
        // except it is broke dw about it
        while (randomizedWaves.Count > maxWaves)
        {
            randomizedWaves.Remove(randomizedWaves[maxWaves + 1]);
        }

        finalizedWaves = randomizedWaves;

        // spawn wave if theres enough waves to spawn
        // dont think the while statement works lemme try it

        spawningWave();

        /*if (randomizedWaves.Count == 3 && oldWaveNumber <= waveNumber)
        {
            oldWaveNumber = waveNumber;
            currentWave = randomizedWaves[waveNumber];
            spawnWave = InstantiateWave(randomizedWaves[waveNumber].wavePrefab, wavePosition);
        }*/

        /*else
        {
            Debug.Log("uhhhh work please");
            return;
        }*/

        /*waveNumber = 0;

        currentWave = randomizedWaves[waveNumber];
        spawnWave = InstantiateCard(randomizedWaves[waveNumber].wavePrefab, wavePosition);*/
    }

    public void spawningWave()
    {
        if (currentWave == null)
        {
            if (finalizedWaves.Count == maxWaves && oldWaveNumber <= waveNumber && waveNumber < maxWaves)
            {
                oldWaveNumber = waveNumber;
                currentWave = finalizedWaves[waveNumber];
                spawnWave = InstantiateWave(finalizedWaves[waveNumber].wavePrefab, wavePosition);
            }
        }
    }

    // spawn the wave
    GameObject InstantiateWave(GameObject wavePrefab, Transform position)
    {
        GameObject waveGO = Instantiate(wavePrefab, position.position, Quaternion.identity, position);
        GameManager.Instance.changeState(GameManager.GameState.Playing);
        return waveGO;
    }
}
