using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float distanceLimit = 12f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log($"{transform.name}: LoadCamera", gameObject);
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.parent.position, mainCam.position);
        if (this.distance <= this.distanceLimit) return false;
        return true;
    }
}
