using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Joystick joystick;
    public static float tmpSpeed; //for accessing others scripts, speed things.
    public float speed, rotationSpeed;
    private float tiredSpeed;

    static public float staticSpeed;



    private void Awake()
    {
        joystick = FindObjectOfType<Joystick>();
        tmpSpeed = speed;
    }


    private void Start()
    {
        staticSpeed = speed;
        tiredSpeed = tmpSpeed - 0.75f + (SkillTreeTest.durabilityLevel * 0.05f);
    }


    void FixedUpdate()
    {
        if (joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f || joystick.Vertical > 0.2f || joystick.Vertical < -0.2f)
        {
            PlayerAnimationScript.animator.SetBool("isIdle", false);
            PlayerAnimationScript.animator.SetBool("isRunning", true);
            if (CompareTag("InAreaPlayer"))
            {
                PlayerAnimationScript.animator.SetBool("InAreaWalk", true);
            }
            transform.position += transform.forward * Time.deltaTime * staticSpeed * (Mathf.Abs(joystick.Vertical) + Mathf.Abs(joystick.Horizontal));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, rotationCalculator(), 0), rotationSpeed * Time.deltaTime);
        }
        else
        {
            PlayerAnimationScript.animator.SetBool("isIdle", true);
            PlayerAnimationScript.animator.SetBool("isRunning", false);
            PlayerAnimationScript.animator.SetBool("InAreaWalk", false);
        }
    }

    private void Update()
    {
        if (PlayerAnimationScript.animator.GetBool("isTired"))
        {
            staticSpeed = tiredSpeed;
        }
        
    }

    private float rotationCalculator()
    {
        float calculation = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * 180 / Mathf.PI;
        return calculation;
    }


}