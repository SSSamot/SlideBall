using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_InputManager : MonoBehaviour
{
    public bool click;
    public bool slide;

    public static QTE_InputManager instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    void Update()
    {
        //Boost simple
        if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
            click = true;
        else
            click = false;

        //Jump Boost
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved || Input.GetKeyDown(KeyCode.Space))
            slide = true;
        else
            slide = false;
    }

    public Vector2 ReturnPos2D()
    {
        Vector2 pos = Vector2.zero;
        //Rail
        if (Input.touchCount > 0)
        {
            pos = Input.GetTouch(0).position;
        }

        return pos;
    }
}
