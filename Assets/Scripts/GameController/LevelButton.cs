using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private int levelPosition;

    private void Start()
    {
        // textField.text = levelPosition.ToString();
    }

    public void ChangeScene()
    {
        SceneController.LoadScene(levelPosition);
    }

    public void UpdateLevelPosition(int position, string text)
    {
        textField.text = text;
        levelPosition = position;
        
    }
}
