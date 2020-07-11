using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneName;

    public void LoadStartScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
