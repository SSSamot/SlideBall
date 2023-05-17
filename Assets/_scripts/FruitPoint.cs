using UnityEngine;

public class FruitPoint : MonoBehaviour
{
    [SerializeField] int scoreValue = 1;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Singleton.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
