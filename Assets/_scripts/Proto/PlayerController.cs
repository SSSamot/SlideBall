using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float speed = 5f;
     public float rotation_speed = 90f;
     private Vector3 mvmtDirection = Vector3.zero;
     [SerializeField] private CharacterController cc;
    
    
     private float _initialYAngle = 0f;
     private float _appliedGyroYAngle = 0f;
     private float _calibrationYAngle = 0f;
     private Transform _rawGyroRotation;
     private float _tempSmoothing;
    
     private float _smoothing = 0.1f;
    
    private void Update()
    {
        Debug.Log("update !!");
        Camera.main.transform.position = transform.position + new Vector3(0, 3, -8);

        Vector3 move = new Vector3(Input.acceleration.x * speed * Time.deltaTime, 0 , -Input.acceleration.z * speed * Time.deltaTime);
        Vector3 rotationMovement = transform.TransformDirection(move);
        cc.Move(rotationMovement);

        ApplyGyroRotation();
        ApplyCalibration();
        transform.rotation = Quaternion.Slerp(transform.rotation, _rawGyroRotation.rotation , _smoothing);

    }

    void Start()
    {
        Debug.Log("start");
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
        _initialYAngle = transform.eulerAngles.y;

        _rawGyroRotation = new GameObject("GyroRaw").transform;
        _rawGyroRotation.position = transform.position;
        _rawGyroRotation.rotation = transform.rotation;

        //yield return  new WaitForSeconds(1);

        StartCoroutine(CalibrateYAngle());
    }

    IEnumerator CalibrateYAngle()
    {
       _tempSmoothing = _smoothing;
       _smoothing = 1;
       _calibrationYAngle = _appliedGyroYAngle - _initialYAngle;
       yield return null;
       _smoothing = _tempSmoothing;
    }

    void ApplyGyroRotation()
    {
       _rawGyroRotation.rotation = Input.gyro.attitude;
       _rawGyroRotation.Rotate(0f,0f,18f, Space.Self);
       _rawGyroRotation.Rotate(90f, 180f, 0f, Space.World);
       _appliedGyroYAngle = _rawGyroRotation.eulerAngles.y;
    
    }

    void ApplyCalibration()
    {
        _rawGyroRotation.Rotate(0f, -_calibrationYAngle, 0f, Space.World);
    }
}
