using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Rail : MonoBehaviour
{
    public bool railStart;
    public bool railEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (railStart)
                transform.parent.parent.GetChild(1).gameObject.SetActive(true);
            if (railEnd)
                transform.parent.parent.GetChild(1).gameObject.SetActive(false);
        }
    }
}
