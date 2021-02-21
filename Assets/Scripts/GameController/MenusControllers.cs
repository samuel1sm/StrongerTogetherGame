using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusControllers : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetLevelScene()
    {
        AudioManager.Instance.PlaySound(Sound.MouseClick);
        SceneController.LoadLevelMenu();
    }
    
    public void LoadMenuScene()
    {
        AudioManager.Instance.PlaySound(Sound.MouseClick);

        SceneController.LoadMainMenu();
    }
    
    public void CloseGame()
    {
        SceneController.CloseGame();
    }
}
