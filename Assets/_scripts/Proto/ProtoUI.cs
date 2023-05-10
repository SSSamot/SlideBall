using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ProtoUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject playMenu;

    public TextMeshProUGUI textTime;
    private float timer;
    private float minutes;
    private float seconds;
    private string stringMinutes;
    private string stringSeconds;

    public static bool isPaused = false;

    private void Update()
    {
        TimerRun();
    }

    public void TimerRun()
    {
        timer += Time.deltaTime;

        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);

        if (minutes < 10)
        {
            stringMinutes = "0" + minutes;
        } else
        {
            stringMinutes = minutes.ToString();
        }

        if (seconds < 10)
        {
            stringSeconds = "0" + seconds;
        }
        else
        {
            stringSeconds = seconds.ToString();
        }

        textTime.text = stringMinutes + ":" + stringSeconds;
    }

    public void RefreshScene()
    {
        SceneManager.LoadScene(0);
        PauseGame();
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
