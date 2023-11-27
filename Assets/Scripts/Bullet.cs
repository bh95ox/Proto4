using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")|| collision.gameObject.CompareTag("MobSpawner"))
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Destroy(gameObject, 5);
    }
}
