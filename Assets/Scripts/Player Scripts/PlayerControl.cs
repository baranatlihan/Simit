using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Joystick joystick;
    public float speed;
    public float rotationSpeed;

    static public float staticSpeed;



    private void Awake()
    {
        joystick = FindObjectOfType<Joystick>();
    }


    private void Start()
    {
        staticSpeed = speed;
    }


    void FixedUpdate()
    {
        if (joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f || joystick.Vertical > 0.2f || joystick.Vertical < -0.2f)
        {
            PlayerAnimationScript.animator.SetBool("isIdle", false);
            PlayerAnimationScript.animator.SetBool("isRunning", true);
            transform.position += transform.forward * Time.deltaTime * staticSpeed * (Mathf.Abs(joystick.Vertical) + Mathf.Abs(joystick.Horizontal));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, rotationCalculator(), 0), rotationSpeed * Time.deltaTime);
        }
        else
        {
            PlayerAnimationScript.animator.SetBool("isIdle", true);
            PlayerAnimationScript.animator.SetBool("isRunning", false);
        }


    }

    private float rotationCalculator()
    {
        float calculation = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * 180 / Mathf.PI;
        return calculation;
    }


}