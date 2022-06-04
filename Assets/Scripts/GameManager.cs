using System;
using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private RoundData[] roundsConfig;
    [SerializeField] private ShelfHealth shelf;
    [SerializeField] private float roundBufferTime = 3f;

    public Action OnEnemyDestroyed = null;
    public Action OnRoundOver = null;

    private int round = 0;
    private int enemiesLeft = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(StartRound());
    }

    private IEnumerator StartRound()
    {
        OnRoundOver?.Invoke();
        if (roundsConfig.Length <= round)
        {
            Debug.Log("Game over");
            yield break;
        }

        Debug.LogFormat("Get ready for round {0}!", round + 1);
        yield return new WaitForSeconds(roundBufferTime);
        SetupRound(roundsConfig[round]);
    }

    private void SetupRound(RoundData config)
    {
        enemiesLeft = config.Spawns.Length;
        foreach (SpawnData spawnData in config.Spawns)
        {
            StartCoroutine(SpawnInDelay(spawnData));
        }
    }

    private IEnumerator SpawnInDelay(SpawnData spawnData)
    {
        yield return new WaitForSeconds(spawnData.SpawnDelay);
        Instantiate(spawnData.Unit, spawnData.SpawnPosition, Quaternion.Euler(0, 0, 0));
    }

    private void OnEnable()
    {
        shelf.OnShelfHit += CheckGameState;
        OnEnemyDestroyed += EnemyDestroyed;
    }

    private void OnDisable()
    {
        shelf.OnShelfHit -= CheckGameState;
        OnEnemyDestroyed -= EnemyDestroyed;
    }

    private void EnemyDestroyed()
    {
        enemiesLeft--;
        CheckGameState();
    }

    private void CheckGameState()
    {
        if (shelf.IsAlive == false)
            Debug.Log("Game over");
        if (enemiesLeft <= 0)
        {
            Debug.Log("Round won");
            round++;
            StartCoroutine(StartRound());
        }
    }
}
