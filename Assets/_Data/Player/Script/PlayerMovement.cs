using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : TienMonoBehaviour
{
    public Rigidbody2D playerRigid2D;
    public float direction;
    public float speed = 2f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerRigidBody2D();
    }

    protected virtual void LoadPlayerRigidBody2D()
    {
        if (playerRigid2D != null) return;
        playerRigid2D = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direction = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        playerRigid2D.velocity = new Vector3(direction * speed, 0f, 0f);
    }
}
