using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : TienMonoBehaviour
{
    public Transform explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("Enemy"))
        {
            Debug.Log("Destroy player!");
            transform.parent.gameObject.SetActive(false);
            Transform newExplosion = Instantiate(explosion, transform.parent.position, transform.parent.rotation);
            newExplosion.gameObject.SetActive(true);
        }
    }
}
