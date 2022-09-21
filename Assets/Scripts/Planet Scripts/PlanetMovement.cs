using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public float rotationSpeed;

    void FixedUpdate()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, rotationSpeed, 0) * Time.deltaTime;
    }
}
