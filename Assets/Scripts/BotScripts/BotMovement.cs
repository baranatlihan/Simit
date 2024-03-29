﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour, IPooledObject
{
    Bounds bound;

    public Transform player;

    public GameObject spawnEffect;

    private Vector3 tmp;

    [Tooltip("AI Movement")]
    public float moveTime = 3;
    private float timer = 0f;
    private NavMeshAgent navAgent;

    private void Awake()
    {
        player = GameManager.playerStatic.transform;
        navAgent = this.GetComponent<NavMeshAgent>();
        bound = new Bounds(new Vector3(0,0,2f), new Vector3(5f, 0, 8f));
        tmp = transform.position - player.transform.position;
    }

    public void onObjectSpawn()
    {

        StartCoroutine(spawnAnimCoroutine());

        if (GameManager.playerTired)
        {
            navAgent.SetDestination(player.position);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= moveTime && !GameManager.playerTired)
        {
            if (GameManager.playerStatic.CompareTag("InAreaPlayer"))
            {
                navAgent.SetDestination(RandomClosePoint(bound));
                timer = 0f;
            }
            else if(Vector3.Distance(transform.position, player.transform.position) < 3f)
            {
                tmp = transform.position - player.transform.position;

                navAgent.speed = 2.1f;
                navAgent.acceleration = 12;
                navAgent.angularSpeed = 240;


                navAgent.SetDestination(transform.position + tmp);
            }
            else {
                timer = 0f;
                navAgent.SetDestination(RandomPoint(bound));
            }

        }
        else if (GameManager.playerTired)
        {
            navAgent.SetDestination(player.position);
        }

  
    }

    public static Vector3 RandomPoint(Bounds bound)
    {
        return new Vector3(
        Random.Range(bound.min.x, bound.max.x),
        1,
        Random.Range(bound.min.z, bound.max.z)
        );
    }

    public static Vector3 RandomClosePoint(Bounds bound)
    {
        return new Vector3(
        Random.Range(bound.min.x + 1f, bound.min.x + 5f),
        1,
        Random.Range(bound.min.z - 2f, bound.min.z + 5f)
        );
    }


    IEnumerator spawnAnimCoroutine()
    {
        spawnEffect.SetActive(true);
        yield return new WaitForSeconds(1.65f);

        navAgent.SetDestination(RandomPoint(bound));
        player = GameManager.playerStatic.transform;
        spawnEffect.SetActive(false);
    }

}