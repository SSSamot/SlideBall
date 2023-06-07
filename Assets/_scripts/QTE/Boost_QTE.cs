using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boost_QTE : MonoBehaviour
{
    public float jumpForce = 10;

    public bool isBoostSpeed;
    public bool isBoostJump;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isBoostSpeed)
                QTE_Manager.instance.isInSpeedBoost = true;
            if (isBoostJump && other.GetComponent<ManuelJump>().IsBallOnFloor())
            {
                QTE_Manager.instance.jumpForce = jumpForce;
                QTE_Manager.instance.isInJumpBoost = true;
                other.GetComponent<ManuelJump>().enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QTE_Manager.instance.isInSpeedBoost = false;
            QTE_Manager.instance.isInJumpBoost = false;
            other.GetComponent<ManuelJump>().enabled = true;
        }
    }
}
