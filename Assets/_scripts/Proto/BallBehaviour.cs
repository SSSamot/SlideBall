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

    [SerializeField] ParticleSystem qteParticle;
    private ParticleSystem generatedQteParticle;

    public static BallBehaviour instance;

    Rigidbody rBody;

    private Gyroscope gyro;

    private void Start()
    {
        generatedQteParticle = null;
        rBody = GetComponent<Rigidbody>();
        gyro = GetComponent<Gyroscope>();
    }

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
        Vector3 velocityBall = rBody.velocity;

        if (velocityBall.z < speed)
        {
            rBody.velocity = new Vector3(velocityBall.x, velocityBall.y, speed);
        }
        else if(velocityBall.z > speed)
        {
            rBody.velocity -= new Vector3(velocityBall.x, velocityBall.y, 0.2f) * Time.deltaTime;
        }
    }

    public void Combo()
    {
        if(isInObs)
        {
            AddVelocity();
            QteSuccessPlay();
            isInObs = false;
        }
    }

    public void Jump()
    {
        if (isInJump)
        {
            AddJump();
            QteSuccessPlay();
            isInJump = false;
        }
    }

    private void AddVelocity()
    {
        rBody.velocity += new Vector3(0, 0, 10f);
    }

    private void AddJump()
    {
        rBody.velocity += new Vector3(0, 10f, 0);
    }

    public void Respawn(Vector3 pos)
    {
        transform.position = pos;
        rBody.velocity = new Vector3(0, 0, 0);
    }

    public void QteSuccessPlay()
    {
        if (generatedQteParticle == null)
        {
            generatedQteParticle = Instantiate(qteParticle, this.transform.position, Quaternion.identity);
        }

        generatedQteParticle.transform.position = this.transform.position;
        generatedQteParticle.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        generatedQteParticle.Play();

        StartCoroutine(StopFXAfterDelay(generatedQteParticle.main.duration));
    }

    private IEnumerator StopFXAfterDelay(float a_Delay)
    {
        yield return new WaitForSeconds(a_Delay);
        generatedQteParticle.Stop();
    }

    public void ResetGyro()
    {
        Gyroscope newGyroscopeScript = GetComponent<Gyroscope>();
        if (newGyroscopeScript.enabled)
		{
            gyro.Reset();
        }
        

        Old_Gyroscope oldGyroscopeScript = GetComponent<Old_Gyroscope>();
        if (oldGyroscopeScript.enabled)
        {
            oldGyroscopeScript.ResetGyroscope();
        }

            
    }
}
