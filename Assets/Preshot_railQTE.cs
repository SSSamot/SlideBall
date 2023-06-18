using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preshot_railQTE : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RailQTE"))
        {
            transform.GetComponentInParent<RailManager>().SetPosCursor(other.gameObject);
        }
    }
}
