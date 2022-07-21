using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    Bounds bound;
    Vector3 spawnVector;
    float timer;

    public GameObject objToSpawn;
    public int numberToSpawn;
    public float spawnTime;
    private void Awake()
    {
        bound = new Bounds(new Vector3(0, 0, 0), new Vector3(20f, 0, 20f));
    }

    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {

        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                spawnVector = RandomPoint(bound);
                Instantiate(objToSpawn, spawnVector, gameObject.transform.rotation, transform.parent);
            }
            timer = 0;
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
