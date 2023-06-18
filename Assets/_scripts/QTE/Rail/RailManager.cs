using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RailManager : MonoBehaviour
{
    [SerializeField] private GameObject prefabQTE;

    private GameObject ball;
    private Transform spawnQTE;
    private GameObject QTE;
    private GameObject railQTE;

    private void Awake()
    {
        ball = FindObjectOfType<BallBehaviour>().gameObject;
        spawnQTE = transform.parent.transform.GetChild(3).transform;
    }

    public void StartQTE()
    {
        QTE = Instantiate(prefabQTE, spawnQTE.position, spawnQTE.rotation); 
        QTE.transform.parent = spawnQTE.transform;
    }

    private void Update()
    {
        SetPos();
    }

    private void FixedUpdate()
    {
        CheckPosCursor();
    }

    private void SetPos()
    {
        Vector3 posBall = ball.transform.position;
        transform.position = posBall + new Vector3(0, 0, 2);
    }

    private void CheckPosCursor()
    {
        GameObject cursor = transform.GetChild(0).gameObject;
        float radiusCursor = cursor.GetComponent<SphereCollider>().radius * cursor.transform.localScale.x;

        Vector2 posMouse = Input.mousePosition;                                         //pos Mouse in screen
        //Vector2 posMouse = QTE_InputManager.instance.ReturnPos2D();
        Vector2 posCursor = Camera.main.WorldToScreenPoint(cursor.transform.position);  //pos Cursor in screen

        Vector2 dist = posMouse - posCursor;    // Distance between Input and Cursor
        Vector3 dir = dist.normalized;          // Direction from center Cursor to Input pos
        Vector2 maxDist = Camera.main.WorldToScreenPoint(cursor.transform.position + dir * radiusCursor);   //Ditance max between center Cursor and border Cursor
        Vector2 distB = maxDist - posCursor;

        dist = new Vector2(Mathf.Abs(dist.x), Mathf.Abs(dist.y));
        distB = new Vector2(Mathf.Abs(distB.x), Mathf.Abs(distB.y));

        if (dist.x <= distB.x && dist.y <= distB.y && railQTE != null)
        {
            if(railQTE.transform.localScale.z <= 0.1f)
            {
                railQTE.SetActive(false);
                railQTE = null;
                return;
            }
            Debug.Log("QTE rail : true");

            float saveScale = railQTE.transform.localScale.z;
            float meshCalcul = railQTE.transform.position.z - (transform.position.z + 0.5f); //0.5f is a box collider
            railQTE.transform.localScale = new Vector3(railQTE.transform.localScale.x, railQTE.transform.localScale.y, meshCalcul*2);
            float scaleDiff = saveScale - railQTE.transform.localScale.z;
            railQTE.transform.position += new Vector3(0, 0, scaleDiff/2);

            QTE_Manager.instance.QTE_RailResult(true);
        }
        else if(dist.x >= distB.x && dist.y >= distB.y && railQTE != null)
        {
            Debug.Log(" QTE rail : false");
            QTE_Manager.instance.QTE_RailResult(false);
        }
            
    }

    public void SetPosCursor(GameObject obj)
    {
        transform.GetChild(0).gameObject.SetActive(true);

        Vector3 posQTE = obj.transform.position;
        posQTE.z = transform.position.z - 0.5f;

        transform.GetChild(0).transform.position = posQTE;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RailQTE"))
        {
            railQTE = other.gameObject;

            SetPosCursor(railQTE);

            /*Vector3 posQTE = other.transform.position;
            posQTE.z = transform.position.z -0.5f;

            transform.GetChild(0).transform.position = posQTE;

            Vector3 cursor = transform.GetChild(0).transform.position;
            Debug.Log(Camera.main.WorldToScreenPoint(cursor));*/
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("rail exit collider check");
        if (other.CompareTag("RailQTE"))
        {
            railQTE = null;
        }
    }

    public void ResetRail()
    {
        Destroy(QTE);
        //QTE = null;
        railQTE = null;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
