using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public bool isInObs;
    public bool isInJump;

    public static BallBehaviour instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        SpeedBehaviour();
    }

    private void SpeedBehaviour()
    {
        Vector3 velocityBall = GetComponent<Rigidbody>().velocity;

        if (velocityBall.z < 5)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(velocityBall.x, velocityBall.y, 5f);
        }
        else if(velocityBall.z < 5)
        {
            GetComponent<Rigidbody>().velocity -= new Vector3(0, 0, 0.2f) * Time.deltaTime;
        }
    }

    public void Combo()
    {
        if(isInObs)
        {
            AddVelocity();
            isInObs = false;
        }
        else if (isInJump)
        {
            AddJump();
            isInJump = false;
        }
    }

    private void AddVelocity()
    {
        GetComponent<Rigidbody>().velocity += new Vector3(0, 0, 10f);
    }

    private void AddJump()
    {
        GetComponent<Rigidbody>().velocity += new Vector3(0, 10f, 0);
    }
}
