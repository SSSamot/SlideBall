using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{

    public string NameScene;

    public void ReloadSceneByName()
	{
        SceneManager.LoadScene(NameScene);
	}

 
}
