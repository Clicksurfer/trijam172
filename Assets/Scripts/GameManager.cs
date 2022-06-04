using System;
using System.Collections;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private RoundData[] roundsConfig;
    [SerializeField] private ShelfHealth shelf;
    [SerializeField] private float roundBufferTime = 3f;
    [SerializeField] private TMP_Text displayText;

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
        if (roundsConfig.Length <= round)
        {
            ShowText("Game Over.\nThanks for playing!");
            yield break;
        }

        ShowText(string.Format("Get ready for\nround {0}!", round + 1));
        yield return new WaitForSeconds(roundBufferTime);
        OnRoundOver?.Invoke();
        HideText();
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
        {
            ShowText("Game Over.\nYou lose.");
            Time.timeScale = 0;
            return;
        }
        if (enemiesLeft <= 0)
        {
            Debug.Log("Round won");
            round++;
            StartCoroutine(StartRound());
        }
    }

    private void ShowText(string text)
    {
        displayText.text = text;
        Debug.Log("Showing text: " + text);
        displayText.gameObject.SetActive(true);
    }

    private void HideText()
    {
        displayText.gameObject.SetActive(false);
    }
}
