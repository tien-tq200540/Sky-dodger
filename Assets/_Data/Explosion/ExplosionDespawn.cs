using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDespawn : DespawnWhenFinishAnim
{
    protected override void DespawnObject()
    {
        ExplosionSpawner.Instance.Despawn(transform.parent);
    }
}
