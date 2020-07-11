using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameQuit : MonoBehaviour
{
    public string menuScene;

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
