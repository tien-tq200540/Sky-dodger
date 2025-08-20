using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : TienMonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("Enemy"))
        {
            Debug.Log("Destroy player!");
            //transform.parent.gameObject.SetActive(false);
            FXSpawner.Instance.SpawnExplosion(transform.parent.position);
        }
    }
}
