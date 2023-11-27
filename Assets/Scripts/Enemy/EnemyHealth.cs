using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int damageToEnemy = 30;
    public GameObject Spawner;

    private void DeathTrigger()
    {
        Debug.Log("Killed Enemy");
        if(Spawner != null)
        {
            Spawner.GetComponent<MobSpawner>().EnemyID--;
        }
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Reduce enemy health
            Debug.Log("Dmg Emeny");
            health -= damageToEnemy;

            if (health <= 0)
            {
                // Destroy the enemy if its health is 0 or less
                DeathTrigger();

            }
        }
    }
}
