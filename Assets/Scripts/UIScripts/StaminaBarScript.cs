using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class StaminaBarScript : MonoBehaviour
{

    void Update()
    {                                   
        if (!GameManager.playerTired && PlayerAnimationScript.animator.GetBool("isRunning")) 
        {
            GetComponent<Image>().fillAmount -= 0.15f * Time.deltaTime; //7.5 sc

            if(GetComponent<Image>().fillAmount == 0)
            {
                GameManager.playerTired = true;
            }
        }

        if (GameManager.playerStatic.CompareTag("InAreaPlayer"))
        {
            GetComponent<Image>().fillAmount += 0.2f * Time.deltaTime; //5 sc
            GameManager.playerTired = false;
        }
    }
}
