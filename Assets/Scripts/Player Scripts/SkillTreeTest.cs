using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeTest : MonoBehaviour
{
    static public int durabilityLevel = 1; //MAX LEVEL 5, tired speed+
    //static public int speedLevel = 1; //MAX LEVEL 5, normal speed
    //static public int Lung Capacity //MAX LEVEL 5, blue bar
    
    private void Awake()
    {
        if (durabilityLevel > 5)
        {
            durabilityLevel = 5;
        }
        
    }


 


}
