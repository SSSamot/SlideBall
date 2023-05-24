using UnityEngine;
using System.Collections;

public class MoveScene : MonoBehaviour
{
    public float accelerationMultiplier = 2.0f;

    void Update()
    {
        transform.rotation *= Quaternion.Euler(Input.acceleration.y * accelerationMultiplier, -Input.acceleration.x * accelerationMultiplier, 0);
    }
}
