using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        // Load level
        Debug.Log("Loading level" + level);
        GameManager.Singleton.currentLevel = level;
        GameManager.Singleton.LoadScene("MainUI");
        // GameManager.Singleton.LoadScene("level" + level);
    }

    public void LoadTuto()
    {
        // Load tutorial
        // GameManager.Singleton.LoadScene("Tutorial");
    }

    public void LoadMenu()
    {
        // Load MainMenu
        GameManager.Singleton.LoadScene("MainMenu");
    }
}
