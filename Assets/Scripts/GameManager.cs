using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static public float timer;

    [Header("Player Settings")]
    public GameObject player;
    static public GameObject playerStatic;
    static public bool playerTired = false;

    private void Awake()
    {
        timer = 0;
        playerStatic = player;

    }

    private void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(PlayerControl.staticSpeed);
    }
}
