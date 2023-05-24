using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Score")]
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        //score of korok seed
        scoreText.text = "Score: " + score.ToString();
        

    }

    public void AddScore(int value)
    {
        score += value;
    }



}