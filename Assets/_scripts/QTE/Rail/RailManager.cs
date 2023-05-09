using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RailManager : MonoBehaviour
{
    private void Update()
    {
        InputManager();
    }

    private void InputManager()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

            }
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Click");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("Floor"))
                {
                    Debug.Log("Floor touch !!");
                }
            }
        }
    }
}
