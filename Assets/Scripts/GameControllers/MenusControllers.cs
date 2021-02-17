using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusControllers : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetLevelScene()
    {
        SceneController.LoadLevelMenu();
    }
    
    public void LoadMenuScene()
    {
        SceneController.LoadMainMenu();
    }
    
    public void CloseGame()
    {
        SceneController.CloseGame();
    }
}
