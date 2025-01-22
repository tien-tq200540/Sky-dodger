using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    public float spawnTime = 5f;
    public float curTime = 0f;
    public Vector3 spawnPos = new Vector3(0f, 5f, 0f);
    public string enemyToSpawn;

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
