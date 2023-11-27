using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private int MaxMobS_Health;
    [SerializeField] private int DamageReceiving;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private int AmountOfEnemy;
    [SerializeField] private float SpawnerRange;
    public int EnemyID = 0;
    private float xPos;
    private float zPos;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            MaxMobS_Health -= DamageReceiving;
        }
    }


    private void Update()
    {
        if(MaxMobS_Health < 0)
        {
            GameObject.Destroy(gameObject);
        }
        
        ReSpawn();
    }

    private void ReSpawn()
    {
        while(EnemyID < AmountOfEnemy)
        {
            xPos = UnityEngine.Random.Range(-SpawnerRange, SpawnerRange)+gameObject.transform.position.x;
            zPos = UnityEngine.Random.Range(-SpawnerRange, SpawnerRange) + gameObject.transform.position.z;

            Vector3 SpawnpointObject = new Vector3(xPos,gameObject.transform.position.y, zPos);
            Instantiate(EnemyPrefab, SpawnpointObject, Quaternion.identity);
            EnemyID++;
        }
    }
}
