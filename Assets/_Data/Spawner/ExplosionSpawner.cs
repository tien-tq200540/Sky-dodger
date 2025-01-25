using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ExplosionSpawner : Spawner
{
    private static ExplosionSpawner instance;
    public static ExplosionSpawner Instance { get => instance; }

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
