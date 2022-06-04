using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private ShelfHealth shelf;

    public Action OnEnemyDestroyed = null;
    public Action RoundOver = null;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        shelf.OnShelfHit += CheckGameState;
    }

    private void OnDisable()
    {
        shelf.OnShelfHit -= CheckGameState;

    }

    private void CheckGameState()
    {
        if (shelf.IsAlive == false)
            Debug.Log("Game over");
    }
}
