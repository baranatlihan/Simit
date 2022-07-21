using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimitAreaScript : MonoBehaviour
{
    private float tmpSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tmpSpeed = PlayerControl.staticSpeed;

            PlayerAnimationScript.animator.SetBool("isIdle", true);
            PlayerAnimationScript.animator.SetBool("isRunning", false);

            GameManager.playerTired = false;
            GameManager.playerStatic.tag = "InAreaPlayer";

            PlayerControl.staticSpeed /= 4;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InAreaPlayer"))
        {
            GameManager.playerStatic.tag = "Player";
            PlayerControl.staticSpeed = tmpSpeed;
        }

    }
}
