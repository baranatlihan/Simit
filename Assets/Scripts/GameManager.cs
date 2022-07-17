using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static public float timer;

    [Header("Player Settings")]
    public GameObject player;
    static public GameObject playerStatic;
    public bool player_Tired;
    static public bool playerTired;

    private void Awake()
    {
        timer = 0;
        playerStatic = player;
        playerTired = player_Tired;
    }

    private void Update()
    {
        playerTired = player_Tired;
        timer += Time.deltaTime;
    }
}
