using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ProtoUI : MonoBehaviour
{
    public TextMeshProUGUI textTime;
    private float timer;

    private void Update()
    {
        TimerRun();
    }

    public void TimerRun()
    {
        timer += Time.deltaTime;

        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        textTime.text = minutes + ":" + seconds;
    }

    public void RefreshScene()
    {
        SceneManager.LoadScene(0);
    }
}
