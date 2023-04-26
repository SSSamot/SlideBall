using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject obstacle;    

    void Update()
    {
        if(Input.touchCount > 0)
        {
            obstacle.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            obstacle.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
