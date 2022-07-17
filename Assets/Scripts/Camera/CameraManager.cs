using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{




    public GameObject TargetPlayer;
    [SerializeField]
    private Transform mapTopRight;
    [SerializeField]
    private Transform mapBotLeft;
    private Transform target;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;



    private Vector3 startPos;


    void Start()
    {

        target = TargetPlayer.transform;
        startPos = transform.position;



        bottomLeftLimit = mapBotLeft.position;
        topRightLimit = mapTopRight.position;
    }

    void LateUpdate()
    {

        transform.position = new Vector3(target.position.x + startPos.x, target.position.y + startPos.y, target.position.z + startPos.z);

        //keeping camera inside area
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), transform.position.y, Mathf.Clamp(transform.position.z, bottomLeftLimit.z, topRightLimit.z));
    }

}