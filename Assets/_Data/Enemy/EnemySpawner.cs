using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }

    public float spawnTime = 3f;
    public float curTime = 0f;
    public Vector3 spawnPos = new Vector3(0f, 5f, 0f);
    public string enemyToSpawn = "Enemy_1";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 EnemySpawner allow to exist!");
        instance = this;
    }

    private void FixedUpdate()
    {
        curTime += Time.fixedDeltaTime;
        if (curTime >= spawnTime)
        {
            Spawn(enemyToSpawn, spawnPos);
            curTime = 0f;
        }
    }
}
