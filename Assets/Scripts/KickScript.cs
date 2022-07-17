using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickScript : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(AnimatorCoroutine());
    }

    IEnumerator AnimatorCoroutine()
    {
        animator.SetBool("Kick", true);

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("Kick", false);
    }
}
