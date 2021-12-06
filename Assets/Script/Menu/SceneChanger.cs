using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public string nextSceneName;
    public void StartGame()
    {
        LevelManager.lvl = 1;
        SceneManager.LoadScene(nextSceneName);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
