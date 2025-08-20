using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectMoveToTarget : TienMonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected Vector3 target;

    protected virtual void SetTarget(Vector3 target, float newSpeed)
    {
        this.target = target;
        this.speed = newSpeed;
    }

    protected abstract void MoveToTarget();
}
