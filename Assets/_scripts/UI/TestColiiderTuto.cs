using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColiiderTuto : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("collision with the ball");
        }
    }
}
