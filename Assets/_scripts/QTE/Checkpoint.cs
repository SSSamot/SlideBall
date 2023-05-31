using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int scoreSaved;
    public int fruitSaved;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BallBehaviour.instance.checkpoint = transform.position;
            scoreSaved = GameManager.Singleton.GetScore();
            fruitSaved = GameManager.Singleton.GetFruits();

            GameManager.Singleton.PlayerFall = Respawn;
        }
    }

    public void Respawn()
    {
        BallBehaviour.instance.Respawn(transform.position);
        GameManager.Singleton.ResetScore(scoreSaved);
        GameManager.Singleton.ResetFruits(fruitSaved);
    }

}
