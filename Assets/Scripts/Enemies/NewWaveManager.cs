using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWaveManager : MonoBehaviour
{
    [SerializeField] GameObject wavePrefab;

    [SerializeField] Transform cardPositionOne;

    [SerializeField] List<WavesSO> Waves;

    [SerializeField] Transform wavePosition;

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



        /*if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RandomizeNewCards();
            Debug.Log("bbbbbb");
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
            RandomizeNewWaves();
        }
    }
    void RandomizeNewWaves()
    {
        if (waveOne != null) Destroy(waveOne);
        if (waveTwo != null) Destroy(waveTwo);
        if (waveThree != null) Destroy(waveThree);

        List<WavesSO> randomizedWaves = new List<WavesSO>();

        List<WavesSO> availableWaves = new List<WavesSO>(Waves);
        /*availableWaves.RemoveAll(wave =>
            wave.isUnique && alreadySelectedWaves.Contains(wave)
            || wave.unlockLevel > GameManager.Instance.GetCurrentLevel()
        );*/

        if (availableWaves.Count < 3)
        {
            Debug.Log("not enough available waves");
            return;
        }

        while (randomizedWaves.Count < 3)
        {
            WavesSO randomWave = availableWaves[Random.Range(0, availableWaves.Count)];
            if (!randomizedWaves.Contains(randomWave))
            {
                randomizedWaves.Add(randomWave);
            }
        }

        waveOne = InstantiateCard(randomizedWaves[0], wavePosition);
    }

    GameObject InstantiateCard(WavesSO wavesSO, Transform position)
    {
        GameObject waveGO = Instantiate(wavePrefab, position.position, Quaternion.identity, position);
        Card card = waveGO.GetComponent<Card>();
        //card.Setup(wavesSO);
        return waveGO;
    }
}
