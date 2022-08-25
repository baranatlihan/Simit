using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public static bool damage = false;
    void Update()
    {
        if (damage)
        {
            GetComponent<Image>().fillAmount -= 0.025f;

            if (GetComponent<Image>().fillAmount == 0)
            {
                Debug.Log("dead");
            }
            damage = false;
        }


        if (GameManager.playerStatic.CompareTag("InAreaPlayer"))
        {
            GetComponent<Image>().fillAmount += 0.2f * Time.deltaTime; //5 sc
        }
    }
}
