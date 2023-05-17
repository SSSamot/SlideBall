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
    Playing
}

public class GameManager : MonoBehaviour
{
    public delegate void Event(int i);
    public Event FruitHit;

    public static GameManager Singleton;

    [SerializeField]
    float maxComboTime;
    float remainningComboTime;
    float gameTime;
    int fruits;
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
            ScoreUI.text = _score.ToString();
        }
    }

    int tmpscore;
    float scoreMult;
    [SerializeField] TextMeshProUGUI ScoreUI;

    [SerializeField] TextMeshProUGUI TimerUI;

    //GameState gameState = GameState.Playing;


    void Start()
    {
        if (Singleton)
            Destroy(this);
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
        gameTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(gameTime);
        TimerUI.text = string.Format("{0:00}:{1:00}",time.Minutes.ToString(),time.Seconds);
        if (remainningComboTime > 0)
        {
            remainningComboTime -= Time.deltaTime;
            if(remainningComboTime<0)
            {
                scoreMult = 1f;
                score += (int)(tmpscore * scoreMult);
            }
        }   
    }

    void GameStart()
    {
        gameTime = 0;
        remainningComboTime = 0;
        fruits = 0;
    }

    void GameEnd()
    {
        score +=(int)( tmpscore * scoreMult);
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
}
