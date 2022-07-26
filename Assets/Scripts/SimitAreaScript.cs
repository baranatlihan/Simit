using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimitAreaScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAnimationScript.animator.SetBool("isIdle", true);
            PlayerAnimationScript.animator.SetBool("isRunning", false);
            PlayerAnimationScript.animator.SetBool("isTired", false);

            GameManager.playerTired = false;
            GameManager.playerStatic.tag = "InAreaPlayer";

            PlayerControl.staticSpeed /= 4;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InAreaPlayer"))
        {
            PlayerAnimationScript.animator.SetBool("InAreaWalk", false);
            GameManager.playerStatic.tag = "Player";
            PlayerControl.staticSpeed = PlayerControl.tmpSpeed;
        }



    }
}
