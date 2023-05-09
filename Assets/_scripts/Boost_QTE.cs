using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boost_QTE : MonoBehaviour
{
    public bool isBoostSpeed;
    public bool isBoostJump;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isBoostSpeed)
                BallBehaviour.instance.isInObs = true;
            if (isBoostJump)
                BallBehaviour.instance.isInJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BallBehaviour.instance.isInObs = false;
            BallBehaviour.instance.isInJump = false;
        }
    }
}
