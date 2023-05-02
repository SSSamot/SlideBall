using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool modRail;

    public static InputManager instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    void Update()
    {
        if (!modRail) // Normal Mod
        {
            //Boost simple
            if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
            {
                BallBehaviour.instance.Combo();
            }

            //Jump Boost
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved || Input.GetKeyDown(KeyCode.Space))
            {
                BallBehaviour.instance.Jump();
            }
        }
        else // Rail Mod
        {
            if(Input.touchCount > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {

                }
            }
        }
    }
}
