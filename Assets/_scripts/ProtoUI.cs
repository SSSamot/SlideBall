using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProtoUI : MonoBehaviour
{
    public void RefreshScene()
    {
        SceneManager.LoadScene(0);
    }
}
