using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeTest : MonoBehaviour
{
    static public int durabilityLevel = 1; //MAX LEVEL 5
    //
    //

    private void Awake()
    {

        if (durabilityLevel > 5)
        {
            durabilityLevel = 5;
        }
    }


 


}
