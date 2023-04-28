using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public bool IsInObs;

    public static BallBehaviour instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Combo();
    }

    private void Combo()
    {
        if(IsInObs && Input.touchCount > 0)
        {
            AddVelocity();
            IsInObs = false;
        }
    }

    public void AddVelocity()
    {
        GetComponent<Rigidbody>().velocity += new Vector3(0, 0, 10f);
    }
}
