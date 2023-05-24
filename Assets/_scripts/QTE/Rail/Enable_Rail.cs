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
                QTE_Manager.instance.RailMod(transform.parent.gameObject, true);
            if (railEnd)
                QTE_Manager.instance.RailMod(transform.parent.gameObject, false);
        }
    }
}
