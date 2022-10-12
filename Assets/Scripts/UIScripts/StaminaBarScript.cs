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
            GetComponent<Image>().fillAmount -= 0.1f * Time.deltaTime; //10 sc

            if(GetComponent<Image>().fillAmount == 0)
            {
                GameManager.playerTired = true;
            }
        }

        if (GameManager.playerStatic.CompareTag("InAreaPlayer"))
        {
            GetComponent<Image>().fillAmount += 0.5f * Time.deltaTime; //2 sc
            GameManager.playerTired = false;
        }
    }
}
