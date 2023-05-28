using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ProtoUI : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject playMenu;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI fruit;
    [SerializeField] TextMeshProUGUI pauseTime;
    [SerializeField] TextMeshProUGUI pauseScore;
    [SerializeField] TextMeshProUGUI pauseFruit;

    private float timer;
    private float minutes;
    private float seconds;
    private string stringMinutes;
    private string stringSeconds;

    public static bool isPaused;

    void Start()
    {
        GameManager.Singleton.SetUI(time, score, fruit);
        GameManager.Singleton.GameStart();
        isPaused = false;
        Resume();
    }

    public void RefreshScene()
    {
        GameManager.Singleton.GameStart();
        PauseGame();
        GameManager.Singleton.LoadScene("MainUI");
    }

    public void LoadMenu()
    {
        GameManager.Singleton.GameEnd();
        GameManager.Singleton.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        if (isPaused) 
        {
            isPaused = false;   
            Resume();
        } else
        {
            isPaused = true;
            Pause();
        }
    }

    private void Pause()
    {
        pauseTime.text = time.text;
        pauseScore.text = score.text;
        pauseFruit.text = fruit.text;
        playMenu.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        playMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
