using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RailManager : MonoBehaviour
{
    private GameObject ball;

    private void Start()
    {
        ball = FindObjectOfType<BallBehaviour>().gameObject;
        transform.parent.transform.GetChild(3).gameObject.SetActive(true);
        
    }

    private void Update()
    {
        SetPos();

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(Input.mousePosition);
        }
    }

    private void SetPos()
    {
        Vector3 posBall = ball.transform.position;
        transform.position = posBall + new Vector3(0, 0, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if (other.CompareTag("RailQTE"))
        {
            Vector3 posQTE = other.transform.position;
            posQTE.z = transform.position.z -0.5f;

            transform.GetChild(0).transform.position = posQTE;

            Vector3 cursor = transform.GetChild(0).transform.position;
            Debug.Log(Camera.main.WorldToScreenPoint(cursor));
        }
    }
}
