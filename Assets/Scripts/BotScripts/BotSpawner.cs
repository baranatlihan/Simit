using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    Bounds bound, boundStart;
    Vector3 spawnVector;
    float timer;

    public int numberToSpawn;
    public float spawnTime;


    [Header("Spawn When Start")]
    public bool spawnWhenStart;
    public int numberToSpawnStart;
    public GameObject spawnPoint;

    ObjectPooler objectPooler;



    private void Awake()
    {
        bound = new Bounds(new Vector3(0, 0, 0f), new Vector3(5f, 0, 5f));
        boundStart = new Bounds(spawnPoint.transform.position, new Vector3(3f, 0, 3f));
    }

 

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        timer = 0f;
    }

    private void Update()
    {


        if (spawnWhenStart)
        {
            BeginingSpawn();
            spawnWhenStart = false;
        }

        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            Spawn();
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


    private void Spawn()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            spawnVector = RandomPoint(bound);

            objectPooler.SpawnFromPool("Bot", spawnVector, gameObject.transform.rotation);

            //Instantiate(objToSpawn, spawnVector, gameObject.transform.rotation, transform.parent);
        }
    }

    private void BeginingSpawn()
    {
        for (int i = 0; i < numberToSpawnStart; i++)
        {

            spawnVector = RandomPoint(boundStart);

            objectPooler.SpawnFromPool("Bot", spawnVector , gameObject.transform.rotation);

            //Instantiate(objToSpawn, spawnVector, gameObject.transform.rotation, transform.parent);
        }
    }



}
