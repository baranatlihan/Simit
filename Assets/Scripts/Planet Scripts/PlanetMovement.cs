using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, rotationSpeed, 0) * Time.deltaTime;
    }
}
