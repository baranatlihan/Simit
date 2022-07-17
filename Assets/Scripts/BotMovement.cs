using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{
    Bounds bound;

    public Transform player;


    [Tooltip("AI Movement")]
    public float moveTime = 3;
    private float timer = 0f;
    private NavMeshAgent navAgent;

    private void Awake()
    {
        bound = new Bounds(new Vector3(0,0,0), new Vector3(20f, 0, 20f));
        
        navAgent = this.GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        navAgent.SetDestination(RandomPoint(bound));
        player = GameManager.playerStatic.transform;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= moveTime && !GameManager.playerTired)
        {
            timer = 0f;
            navAgent.SetDestination(RandomPoint(bound));
        }
        else if (GameManager.playerTired)
        {
            //"anim change"
            navAgent.SetDestination(player.position);
        }
    }

    public static Vector3 RandomPoint(Bounds bound)
    {
        return new Vector3(
        Random.Range(bound.min.x, bound.max.x),
        Random.Range(bound.min.y, bound.max.y),
        Random.Range(bound.min.z, bound.max.z)
        );
    }

}