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
    public Image panelTutoImage;

    public Sprite swipe;
    public Sprite rotate;


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
                panelTutoText.text = "Inclinez votre téléphone vers la droite ou la gauche pour déplacer l'orange";
                panelTutoImage.sprite = rotate;
                break;
            case 1:
                panelTutoText.text = "Appuyez sur l'écran quand votre orange est sur le booster de vitesse";
                panelTutoImage.sprite = swipe;
                break;
            case 2:
                panelTutoText.text = "Swipe vers le haut quand l'orange est sur le booster de saut";
                break;
            case 3:
                panelTutoText.text = "Swipez vers le haut pour faire un petit saut";
                break;
            case 4:
                panelTutoText.text = "Maintenez le doigt sur les pailles (bien au centre), relâchez uniquement quand la paille à disparu";
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

