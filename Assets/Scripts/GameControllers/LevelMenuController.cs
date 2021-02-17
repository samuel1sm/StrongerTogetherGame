using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var childs = transform.GetComponentsInChildren<LevelButton>();
        int ableScenes = SceneController.GetSceneQTD() - SceneController.MenuScenesQtd;
        for (int i = 0; i <  ableScenes; i++)
        {
            childs[i].UpdateLevelPosition(i +  SceneController.MenuScenesQtd, (i +1).ToString());
        }
        
        for (int i = transform.childCount -1 ; i >=  ableScenes; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
