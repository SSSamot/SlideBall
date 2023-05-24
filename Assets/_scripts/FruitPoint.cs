using UnityEngine;

public class FruitPoint : MonoBehaviour
{
    public int scoreValue = 1;
    public GameObject particleEffect;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter tag Player OK");
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
            ShowParticleEffect();
        }
    }

    void ShowParticleEffect()
    {
        if (particleEffect != null)
        {
            GameObject particles = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(particles, 0.5f);
        }
    }
}
