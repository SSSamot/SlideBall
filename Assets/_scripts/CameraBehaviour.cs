using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;

    void Update()
    {

        if (objectToFollow != null)
        {
            // Calculate the new position of the camera
            Vector3 newPosition = objectToFollow.position + offset;

            // Set the camera's position to the new position
            transform.position = newPosition;
        }
    }
}