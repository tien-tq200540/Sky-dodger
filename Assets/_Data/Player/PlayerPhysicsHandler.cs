using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPhysicsHandler : TienMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigid2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this.rigid2D != null) return;
        this.rigid2D = GetComponent<Rigidbody2D>();
        Debug.LogWarning($"{transform.name}: LoadRigidbody2D", gameObject);
    }

    public virtual void MoveTo(Vector3 pos)
    {
        this.rigid2D.MovePosition(pos);
    }
}
