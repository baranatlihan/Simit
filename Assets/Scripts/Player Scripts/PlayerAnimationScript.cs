using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    static public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isIdle", true);
        animator.SetBool("isRunning", false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bot") && !GameManager.playerTired)       //if or coroutine, which effective?
        {
            StartCoroutine(AnimatorCoroutine());
        }

    }

    IEnumerator AnimatorCoroutine()
    {
        animator.SetBool("Kick", true);

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("Kick", false);
    }

    private void Update()
    {
        if (GameManager.playerTired)
        {
            animator.SetBool("isTired", true);
        }else if (!GameManager.playerTired)
        {
            animator.SetBool("isTired", false);
        }

        if (GameManager.playerStatic.CompareTag("InAreaPlayer"))
        {
            animator.SetBool("isIdle", true);
        }
        else
        {
            animator.SetBool("isIdle", false);
        }
    }
}
