using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f; 

    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Vector3 rotationRate = Input.gyro.rotationRateUnbiased;

        float movement = rotationRate.z * movementSpeed * Time.deltaTime;

        transform.Translate(new Vector3(movement, 0, 0), Space.World);

        //transform.position += new Vector3(0, rotationRate.x * movementSpeed * Time.deltaTime, 0); 


    }
}