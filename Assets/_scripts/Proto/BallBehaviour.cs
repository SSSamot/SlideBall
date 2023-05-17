using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public bool isInObs;
    public bool isInJump;

    public float speed;
    public Vector3 checkpoint;

    public static BallBehaviour instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    
    void Update()
    {
        SetCamera();
        SpeedBehaviour();
    }

    public void SetCamera()
    {
        Camera.main.transform.position = transform.position + new Vector3(0, 3, -8);
    }


    private void SpeedBehaviour()
    {
        Vector3 velocityBall = GetComponent<Rigidbody>().velocity;

        if (velocityBall.z < speed)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(velocityBall.x, velocityBall.y, speed);
        }
        else if(velocityBall.z < speed)
        {
            GetComponent<Rigidbody>().velocity -= new Vector3(velocityBall.x, velocityBall.y, 0.2f) * Time.deltaTime;
        }
    }

    public void Combo()
    {
        if(isInObs)
        {
            AddVelocity();
            isInObs = false;
        }
    }

    public void Jump()
    {
        if (isInJump)
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

    public void RespawnLastCheckpoint()
    {
        transform.position = checkpoint;
    }
}
