using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
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

        GameObject cursor = transform.GetChild(0).gameObject;
        float radiusCursor = cursor.GetComponent<SphereCollider>().radius * cursor.transform.localScale.x;
        //Debug.DrawRay(cursor.transform.position, cursor.transform.forward * 10, Color.red);
        if (Input.GetKeyDown(KeyCode.M))
        {
            Vector2 posMouse = Input.mousePosition;                                         //pos Mouse in screen
            Vector2 posCursor = Camera.main.WorldToScreenPoint(cursor.transform.position);  //pos Cursor in screen

            Vector2 dist = posMouse - posCursor;    // Distance between Input and Cursor
            Vector3 dir = dist.normalized;          // Direction from center Cursor to Input pos
            Vector2 maxDist = Camera.main.WorldToScreenPoint(cursor.transform.position + dir * radiusCursor);   //Ditance max between center Cursor and border Cursor
            Vector2 distB = maxDist - posCursor;

            //Debug.Log("Dir : " + dir);
            //Debug.Log("Dist : Center-Input = " + dist + "; Center-MaxBorder = " + distB);

            dist = dist.Abs();
            distB = distB.Abs();
            //Debug.Log("Abs : Input = " + dist + "; Border = " + distB);

            if (dist.x <= distB.x && dist.y <= distB.y)
                Debug.Log("true");
            else
                Debug.Log("false");
        }

        // Test Calcul pos in WorldSpace
            // pos test tempo 
        //Vector3 posCheckMaxDist = transform.GetChild(2).transform.position;
        //Vector3 posMouseWorld = transform.GetChild(1).transform.position;
        //Vector2 posCursor2D = cursor.transform.position;

            //Calcul
        //Vector2 dist = posMouseWorld - cursor.transform.position;
        //Vector2 dir = dist.normalized;
        //Vector2 maxDist = posCursor2D + dir * radiusCursor;

        //posCheckMaxDist = maxDist;
        //posCheckMaxDist.z = transform.position.z - 0.5f;
        //transform.GetChild(2).transform.position = posCheckMaxDist;
        
        //Debug.Log(dir);
        //Debug.Log("dist Center-Touch : " + dist + "; dist Center-MaxBorder : " + (posCheckMaxDist - cursor.transform.position));
        //Debug.Log("Sreen : pos Cursor = " + posCursor + "; pos CheckMaxDist = " + Camera.main.WorldToScreenPoint(posCheckMaxDist));
        //Debug.DrawRay(cursor.transform.position, dir * 10, Color.blue);  //top
        //Debug.Log("pos Cursor : " + cursor.transform.position + "; pos Mouse : " + posMouseWorld);
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
