using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject obstacle;    

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space))
        {
            BallBehaviour.instance.Combo();
            obstacle.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            obstacle.GetComponent<Renderer>().material.color = Color.red;
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Vector2 pos = Input.GetTouch(0).position;
        }
    }
}
