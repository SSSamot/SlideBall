using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    private static CanvasManager instance;
    public GameObject tutorialPanel;
    public TextMeshProUGUI panelTutoText;


    // Public property to access the instance
    public static CanvasManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        // Check if an instance already exists
        if (instance != null && instance != this)
        {
            // Destroy the duplicate instance
            Destroy(gameObject);
            return;
        }

        // Set the instance
        instance = this;

        // Keep the manager object persistent between scenes
        DontDestroyOnLoad(gameObject);
    }

    public void ShowTutorial(int id)
    {
        tutorialPanel.SetActive(true);
        StopTime();

        switch (id)
        {
            case 0:
                panelTutoText.text = "Gyroscope Tutoriel";
                break;
            case 1:
                panelTutoText.text = "1 Tutoriel";
                break;
            case 2:
                panelTutoText.text = "2 Tutoriel";
                break;
            case 3:
                panelTutoText.text = "3 Tutoriel";
                break;
            case 4:
                panelTutoText.text = "4 Tutoriel";
                break;
            default:
                print("none");
                break;
        }
    }

    public void OnClickClose(){
        tutorialPanel.SetActive(false);
        ResumeTime();
    }

    private void StopTime(){
        Time.timeScale = 0;
    }

    private void ResumeTime(){
        Time.timeScale = 1;
    }
}

