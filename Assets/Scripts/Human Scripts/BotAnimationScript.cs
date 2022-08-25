using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimationScript : MonoBehaviour
{
    private Animator animator;
    private bool kickAgain;

    private void Start()
    {
        kickAgain = true;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.playerTired && kickAgain)
        {
            StartCoroutine(BotKickCoroutine());
            Debug.Log("KICKED");
            kickAgain = false;
        }
    }

    void Update()
    {
        if (GameManager.playerTired)
        {
            animator.SetBool("isTired", true);
        }
        else
        {
            animator.SetBool("isTired", false);
        }

        if (GameManager.playerStatic.tag.Equals("InAreaPlayer"))
        {
            animator.SetBool("inArea", true);
        }
        else
        {
            animator.SetBool("inArea", false);
        }        
    }


    IEnumerator BotKickCoroutine()
    {
        animator.SetBool("BotKick", true);
        Handheld.Vibrate();
        HealthBarScript.damage = true;

        yield return new WaitForSeconds(1f);

        animator.SetBool("BotKick", false);
        kickAgain = true;
    }
}
