using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    [SerializeField]
    float sensibility = 5f; 
    float speedMult = 1f;
    float acceleration = 0f;
    Rigidbody rBody;

    void Start()
    {
        Input.gyro.enabled = true;
        rBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 rotationRate = -Input.gyro.rotationRateUnbiased;
        acceleration += rotationRate.z * sensibility ;
        rBody.velocity += new Vector3(acceleration * speedMult * Time.deltaTime, 0, 0);
    }

    public  void Reset()
    {
        acceleration = 0;
        rBody.velocity = new Vector3(0, 0, 0);
    }
}