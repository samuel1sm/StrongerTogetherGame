using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    
    public static int MenuScenesQtd = 2;

    public static int GetSceneQTD()
    {
        return SceneManager.sceneCountInBuildSettings;
    }
    public static int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public static void LoadNextScene()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int currentScene = GetCurrentScene();

        SceneManager.LoadScene(sceneCount == currentScene + 1 ? 0 : currentScene + 1);
    }

    public static void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadLevelMenu()
    {
        SceneManager.LoadScene(1);
    }

    public static void CloseGame()
    {
        Application.Quit();
    }
}