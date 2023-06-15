using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    private int currentLevel;
    private int finalScore;

    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI fruit;

    [SerializeField] GameObject[] starsArray;

    void Start()
    {
        currentLevel = GameManager.Singleton.currentLevel;
        finalScore = GameManager.Singleton.FinalScore();

        score.text = string.Format("{0:000000}", finalScore);
        time.text = string.Format("{0:00}:{1:00}", GameManager.Singleton.finalTime.Minutes, GameManager.Singleton.finalTime.Seconds);
        fruit.text = string.Format("{0:000}", GameManager.Singleton.fruits);

        SetStars();
    }

    public void LoadMenu()
    {
        // Go to main menu
        GameManager.Singleton.LoadScene("LevelSelect");
    }

    public void ReplayLevel()
    {
        // Replay current level
        if (currentLevel == 0)
		{
            GameManager.Singleton.LoadScene("Tuto");
        }
        else
		{
            GameManager.Singleton.LoadScene("level" + currentLevel);
        }
        
        
    }


    public void NextLevel()
    {
        // Go to next level
        if (GameManager.Singleton.currentLevel > GameManager.Singleton.levelTotal)
        {
            // GameManager.Singleton.LoadScene("level" + currentLevel);
        }
    }

    private void SetStars()
    {
        int stars;
        if (finalScore > 25000)
        {
            stars = 3;
        } else if (finalScore > 15000)
        {
            stars = 2;
        } else if (finalScore > 5000)
        {
            stars = 1;
        } else
        {
            stars = 0;
        }
        
        for (int i = 0; i < stars; i++)
        {
            starsArray[i].SetActive(true);
        }
    }
}
