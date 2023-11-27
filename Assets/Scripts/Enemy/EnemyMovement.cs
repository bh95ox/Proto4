using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform EnemyGun;
    [SerializeField] private int RangeTarget;
    [SerializeField] private float AttackTime;
    [SerializeField] private int DamageToPlayer;
    [SerializeField] private GameObject EnemyBullet;
  
    public LayerMask WhatIsGround, WhatIsPlayer;
    public float EnemyMovementSpeed;
    public float shootForce;

    private bool PlayerInSight;
    private bool attackReady;
    private float tick;
    private Playerhealth PlayerHP;
    private Transform Player;
    private Transform Enemy;
    private NavMeshAgent navMeshAgent;

    //patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkpointRange;

    //States
    public float sightRange, AttackRange;
    public bool playerInSightRange, PlayerInAttackRange;

    private void Start()
    {
        GameObject getPlayer = GameObject.FindWithTag("Player");
        if(getPlayer != null )
        {
            Player = getPlayer.transform;
        }
        Enemy = gameObject.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = EnemyMovementSpeed;
        PlayerHP = getPlayer.GetComponent<Playerhealth>();
    }

    private void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet){ navMeshAgent.SetDestination(walkPoint);}
            

        Vector3 distanceToWalkpoint = transform.position - walkPoint;

        if (distanceToWalkpoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomz = Random.Range(-walkpointRange, walkpointRange);
        float randomx = Random.Range(-walkpointRange, walkpointRange);

        walkPoint = new Vector3(transform.position.x + randomx, +transform.position.y, transform.position.z + randomz);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, WhatIsGround))
        {
            walkPointSet = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsPlayer);
        navMeshAgent.speed = 1;

        TurnToPlayer();
        IsReadyToAttack();

        if (!playerInSightRange && !PlayerInAttackRange)
        {
            Patrol();
        }

        if (playerInSightRange && !PlayerInAttackRange)
        {
            ;

            if (playerInSightRange && !PlayerInAttackRange)
                navMeshAgent.speed = 3;
        }

        if (playerInSightRange && PlayerInAttackRange)
        {
            TurnToPlayer();
        }

    }

    private void IsReadyToAttack()
    {
        if (tick < AttackTime)
        {
            tick += Time.deltaTime;
            attackReady = false;
        }
        else
        {
            attackReady = true;
        }
    }

    private void TurnToPlayer()
    {
        PlayerInSight = Physics.CheckSphere(transform.position, RangeTarget, WhatIsPlayer);
        if (PlayerInSight)
        {

            Vector3 lookVector = Player.position - Enemy.transform.position;
            Quaternion rotation = Quaternion.LookRotation(lookVector);
            Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, rotation, 0.1f);

            if (attackReady)
            {
                tick = 0f;
                Ray ray = new(EnemyGun.position, EnemyGun.forward);


                if (Physics.Raycast(ray, out RaycastHit raycastHit, RangeTarget))
                {
                    if (raycastHit.transform != null)
                    {
                        GameObject currentBullet = Instantiate(EnemyBullet, EnemyGun.position, Quaternion.identity);
                        currentBullet.GetComponent<Rigidbody>().AddForce(EnemyGun.transform.position * shootForce, ForceMode.Impulse);
                        PlayerHP.DamageTaken(DamageToPlayer);
                    }
                }
                else
                {
                    Debug.Log("ENEMY: FAILED RAYCAST");
                }
            }
        }
    }

}
