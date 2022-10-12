using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSunlightManager : MonoBehaviour
{
    public GameObject fakeSunlight;
    public int speed = 5;




    void Update()
    {
        //fakeSunlight.transform.rotation = Quaternion.Euler(new Vector3(GameManager.timer  * 360f - 90f, GameManager.timer  * 360f-20, 0));
    } 

}
