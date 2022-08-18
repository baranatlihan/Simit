using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollWhenSpawn : MonoBehaviour
{
    private Vector3 tmp; //character hits direction vector
    private void Start()
    {
        tmp = this.transform.position - GameManager.playerStatic.transform.position; 
        this.transform.GetComponentInChildren<Rigidbody>().AddForce(tmp.x*100, 200f, tmp.z*100, ForceMode.Impulse);
        Destroy(this.gameObject, 3);
    }


}
