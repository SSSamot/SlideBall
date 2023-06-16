using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_Gyroscope : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 0.5f; // Movement speed in units per second
    float accumulativeRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the gyroscope rotation rate
        Vector3 rotationRate = -Input.gyro.rotationRateUnbiased;

        // Accumulate the rotation rate over time to be used in the movement calculation
        accumulativeRotation += rotationRate.z * Time.deltaTime;

        // Apply movement speed
        float movement = accumulativeRotation * movementSpeed;

        // Apply movement to the transform's position
        transform.Translate(new Vector3(movement, 0, 0), Space.World);

        //transform.position += new Vector3(0, rotationRate.x * movementSpeed * Time.deltaTime, 0); 

        // Clamp the position to the screen bounds  


    }
}