using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private void FixedUpdate()
    {
        transform.parent.Translate(new Vector3(0f, (-1) * speed, 0f) * Time.fixedDeltaTime);
    }
}
