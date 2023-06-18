using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Rail : MonoBehaviour
{
    public bool railStart;
    public bool railEnd;
    public Vector3 offsetCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (railStart)
            {
                QTE_Manager.instance.RailMod(transform.parent.transform.GetChild(0).gameObject, true);
                other.GetComponent<Gyroscope>().enabled = false;
                Camera.main.GetComponent<CameraBehaviour>().offset = offsetCamera;

                Debug.Log("Rotate Cam pls");
                //Camera.main.transform.rotation = new Quaternion(45, 0, 0, 0);
            }
            if (railEnd)
            {
                QTE_Manager.instance.RailMod(transform.parent.transform.GetChild(0).gameObject, false);
                other.GetComponent<Gyroscope>().enabled = true;
                Camera.main.GetComponent<CameraBehaviour>().offset = offsetCamera;
                Camera.main.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
}
