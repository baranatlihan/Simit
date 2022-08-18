using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimationScript : MonoBehaviour
{
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
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

    /*IEnumerator KickCoroutine()
    {
        animator.SetBool("Kick", true);

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("Kick", false);
    }*/
}
