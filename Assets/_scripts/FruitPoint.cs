using UnityEngine;

public class FruitPoint : MonoBehaviour
{
    public int scoreValue = 1;
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
        }
    }
}
