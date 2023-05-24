using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void MenuPlay()
    {
        // Change Scene
        GameManager.Singleton.LoadScene("LevelSelect");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

}
