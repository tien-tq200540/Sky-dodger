using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public virtual void SpawnExplosion(Vector3 spawnPos)
    {
        Spawn("Explosion", spawnPos);
    }
}
