using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public enum GameState
{
    Paused,
    Sliding,
    Playing,
    Menu
}

public class GameManager : MonoBehaviour
{
    public delegate void Event(int i);
    public Event FruitHit;

    public delegate void PlayerEvent();
    public PlayerEvent PlayerFall;

    public static GameManager Singleton;

    [SerializeField]
    float maxComboTime;
    float remainningComboTime;
    float gameTime;
    private int _fruits;
    public int fruits
    {
        get
        {
            return _fruits;
        }
        set
        {
            _fruits = value;
            if(fruitUI)
                fruitUI.text = string.Format("{0:000}", fruits);
        }
    }
    private int _score;
    int score
    {
        get
        {
            return _score;
        }
        set 
        {
            _score = value;
            if(scoreUI)
                scoreUI.text = string.Format("{0:000000}", _score);
        }
    }

    int tmpscore;
    float scoreMult;
    TextMeshProUGUI scoreUI;
    TextMeshProUGUI timerUI;
    TextMeshProUGUI fruitUI;

    public GameState gameState = GameState.Menu;

    public int currentLevel;
    public int levelTotal = 3;

    public TimeSpan finalTime;


    void Start()
    {
        if (Singleton && Singleton != this)
            Destroy(gameObject);
        else
            Singleton = this;
            
        DontDestroyOnLoad(this);
        
        gameTime = 0;
        fruits = 0;
        score = 0;
        tmpscore = 0; 
        scoreMult = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Playing)
        {
            gameTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(gameTime);
            timerUI.text = string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
            if (remainningComboTime > 0)
            {
                remainningComboTime -= Time.deltaTime;
                if (remainningComboTime < 0)
                {
                    scoreMult = 1f;
                    score += (int)(tmpscore * scoreMult);
                }
            }
        }
    }

    public void GameStart()
    {
        gameState = GameState.Playing;
        gameTime = 0;
        remainningComboTime = 0;
        fruits = 0;
        tmpscore = 0;
        scoreMult = 1f;
    }

    public void GameEnd()
    {
        gameState = GameState.Menu;
        score += (int)(tmpscore * scoreMult);
        finalTime = TimeSpan.FromSeconds(gameTime);
        LoadScene("EndMenu");
    }

    public void AddScore(int s)
    {
        fruits++;
        if (remainningComboTime > 0)
            tmpscore += s;
        else
            score += s;
    }

    public int FinalScore()
    {
        return (30000 - (int)gameTime) + score;
    }

    public void LoadScene(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void QTEWon()
    {
        if (remainningComboTime < 0)
            remainningComboTime = maxComboTime;
        scoreMult += 0.1f;
    }

    public void SetUI(TextMeshProUGUI timer, TextMeshProUGUI score, TextMeshProUGUI fruit)
    {
        timerUI = timer;
        scoreUI = score;
        fruitUI = fruit;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetFruits()
    {
        return fruits;
    }

    public void ResetFruits(int i)
    {
        fruits = i;
    }
        
    public void ResetScore(int i)
    {
        score = i;
    }
}
