using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyCatalogEntry
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField, Min(0f)] private float weight = 1f;
    [SerializeField, Min(0)] private int cost = 1;
    [SerializeField, Min(0)] private int minWave = 0;
    [SerializeField, Min(0)] private int maxWave = 6; // Phase 1: 7-wave run (0..6)

    public GameObject EnemyPrefab => enemyPrefab;
    public float Weight => weight;
    public int Cost => cost;
    public int MinWave => minWave;
    public int MaxWave => maxWave;
}
