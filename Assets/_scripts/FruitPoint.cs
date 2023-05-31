using UnityEngine;

public class FruitPoint : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1;
    public GameObject particleEffect;

    void Start()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter tag Player OK");
            GameManager.Singleton.AddScore(scoreValue);
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
