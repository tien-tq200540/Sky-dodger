using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : TienMonoBehaviour
{
    private void FixedUpdate()
    {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (!CanDespawn()) return;
        this.DespawnObject();
    }

    //Basic despawn
    protected virtual void DespawnObject()
    {
        Destroy(transform.parent);
    }

    protected abstract bool CanDespawn();
}
