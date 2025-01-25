using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    protected override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }
}
