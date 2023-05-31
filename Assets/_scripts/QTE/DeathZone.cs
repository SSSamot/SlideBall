using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Vector3 vec = other.GetComponent<Rigidbody>().velocity;
            other.GetComponent<Rigidbody>().velocity = new Vector3(vec.x,vec.y, BallBehaviour.instance.speed);
            BallBehaviour.instance.RespawnLastCheckpoint();
        }
    }
}
