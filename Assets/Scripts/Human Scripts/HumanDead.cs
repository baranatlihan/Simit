using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDead : MonoBehaviour
{
    public GameObject ragdollObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GameManager.playerTired)
        {
            HitToSpawn();
        }
    }


    private void HitToSpawn()
    {
        Instantiate(ragdollObj, transform.position, gameObject.transform.rotation, transform.parent);
        this.gameObject.SetActive(false);
        //Destroy(this.gameObject);
    }

}
