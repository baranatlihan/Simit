using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour, IPooledObject
{
    Bounds bound;

    public Transform player;
  

    [Tooltip("AI Movement")]
    public float moveTime = 3;
    private float timer = 0f;
    private NavMeshAgent navAgent;

    private void Awake()
    {
        player = GameManager.playerStatic.transform;
        navAgent = this.GetComponent<NavMeshAgent>();
        bound = new Bounds(new Vector3(0,0,0), new Vector3(20f, 0, 20f));
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
            timer = 0f;
            if (GameManager.playerStatic.CompareTag("InAreaPlayer"))
            {
                navAgent.SetDestination(RandomClosePoint(bound));
            }
            else
            {
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
        Random.Range(bound.min.x + 5f, bound.min.x + 15f),
        1,
        Random.Range(bound.min.z + 5f, bound.min.z + 15f)
        );
    }


    IEnumerator spawnAnimCoroutine()
    {
        yield return new WaitForSeconds(1.5f);

        navAgent.SetDestination(RandomPoint(bound));
        player = GameManager.playerStatic.transform;
    }

}