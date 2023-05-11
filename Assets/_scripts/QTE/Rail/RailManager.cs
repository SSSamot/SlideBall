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
        Debug.DrawRay(cursor.transform.position, cursor.transform.forward * 10, Color.red);
        //Debug.DrawRay(cursor.transform.position + new Vector3(0, radiusCursor, 0), cursor.transform.forward * 10, Color.blue);  //top
        //Debug.DrawRay(cursor.transform.position + new Vector3(0, -radiusCursor, 0), cursor.transform.forward * 10, Color.blue); //bot
        //Debug.DrawRay(cursor.transform.position + new Vector3(radiusCursor, 0, 0), cursor.transform.forward * 10, Color.blue);  //right
        //Debug.DrawRay(cursor.transform.position + new Vector3(-radiusCursor, 0, 0), cursor.transform.forward * 10, Color.blue); //left
        /*if (Input.GetKeyDown(KeyCode.M))
        {
            Vector2 posMouse = Input.mousePosition;
            Vector2 posCursor = Camera.main.WorldToScreenPoint(cursor.transform.position); //Pos cursor in screen
            Vector2 posRadiusCursor = Camera.main.WorldToScreenPoint(cursor.transform.position + new Vector3(0, radiusCursor, 0)); //Pos border cursor (up) in screen

            //Debug.Log("Mouse pos : " + posMouse + "; Cursor pos : " + posCursor);
            //Debug.Log("Pos Cursor with radius : " + posRadiusCursor);

            //Vector2 dir = posCursor - posMouse;
            //Vector2 posRadius = posCursor + 
            Vector3 posMouseWorld = Camera.main.ScreenToWorldPoint(posMouse); 
            posMouseWorld.z = cursor.transform.position.z;
            Vector2 dir = cursor.transform.position - posMouseWorld;
            Debug.DrawRay(cursor.transform.position, dir * 10, Color.blue);  //top

            Debug.Log("pos Cursor : " + cursor.transform.position + "; pos Mouse : " + posMouseWorld);
        }*/

        Vector2 posMouse = Input.mousePosition;
        Vector2 posCursor = Camera.main.WorldToScreenPoint(cursor.transform.position); //Pos cursor in screen
        Vector2 posRadiusCursor = Camera.main.WorldToScreenPoint(cursor.transform.position + new Vector3(0, radiusCursor, 0)); //Pos border cursor (up) in screen

        //Debug.Log("Mouse pos : " + posMouse + "; Cursor pos : " + posCursor);
        //Debug.Log("Pos Cursor with radius : " + posRadiusCursor);

        Vector3 posMouseWorld = transform.GetChild(1).transform.position;
        Vector2 dir = posMouseWorld - cursor.transform.position;



        Debug.Log(dir);
        Debug.DrawRay(cursor.transform.position, dir.normalized * 10, Color.blue);  //top
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
