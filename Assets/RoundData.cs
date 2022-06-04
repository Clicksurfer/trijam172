using UnityEngine;
using System;

[CreateAssetMenu(fileName = "roundData", menuName = "RoundData", order = 1)]
public class RoundData : ScriptableObject
{
    public SpawnData[] Spawns;
}

[Serializable]
public class SpawnData
{
    public SpawnData(GameObject unit, float spawnDelay, Vector2 spawnPosition)
    {
        Unit = unit;
        SpawnDelay = spawnDelay;
        SpawnPosition = spawnPosition;
    }

    public GameObject Unit;
    public float SpawnDelay;
    public Vector2 SpawnPosition;
}