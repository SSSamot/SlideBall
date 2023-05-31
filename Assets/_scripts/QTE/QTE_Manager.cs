using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_Manager : MonoBehaviour
{
    public float jumpForce;

    public bool isInSpeedBoost;
    public bool isInJumpBoost;

    private GameObject _rail; // Stock actual rail manager

    public static QTE_Manager instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Update()
    {
        QTE_SpeedSuccess();
        QTE_JumpSuccess();

        // SUP fonction ###########################################################################################################
        
        /*
            if (BallBehaviour.instance.transform.position.y < -10)
        {
            ResetActualRail();
            BallBehaviour.instance.transform.position = new Vector3(0, 1, -45);
        } 

        */
        // ########################################################################################################################
    }

    public void RailMod(GameObject rail, bool railMod)
    {
        rail.SetActive(railMod);
        _rail = rail;
        if (railMod)
            rail.GetComponent<RailManager>().StartQTE();
    }

    public void QTE_SpeedSuccess()
    {
        // Call Function in GameManager for add ScoreMultiply and Velocity Z (speed) or speed var
        if (isInSpeedBoost && QTE_InputManager.instance.click)
        {
            //GameManager.Singleton.QTEWon();
            BallBehaviour.instance.GetComponent<Rigidbody>().velocity += new Vector3(0, 0, 10f); // change by function GameManager
            isInSpeedBoost = false; 
        }
    }
    
    public void QTE_JumpSuccess()
    {
        //Call function in GameManager or Ball instance for add Velocity Y (jump)
        if (isInJumpBoost && QTE_InputManager.instance.slide)
        {
            BallBehaviour.instance.GetComponent<Rigidbody>().velocity += new Vector3(0, jumpForce, 0); // change by function GameManager
            isInJumpBoost = false;
        }
    }

    public void QTE_RailResult(bool result)
    {
        // If Success : is finish and player continu to play. Else Miss : Ball falling in void and restart actual section
        if (!result)
            _rail.transform.parent.gameObject.SetActive(false);
    }

    public void ResetActualRail()
    {
        _rail.transform.parent.gameObject.SetActive(true);
        _rail.GetComponent<RailManager>().ResetRail();
        _rail.SetActive(false);
    }
}
