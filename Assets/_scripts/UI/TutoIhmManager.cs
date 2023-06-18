using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoIhmManager : MonoBehaviour
{

    public int IdTuto = 0;

    void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Tuto 0");
                CanvasManager.Instance.ShowTutorial(IdTuto);
            }
        }
}
