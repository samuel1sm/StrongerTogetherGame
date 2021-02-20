using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableThings : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
         SceneController.ResetScene();
    }
}
