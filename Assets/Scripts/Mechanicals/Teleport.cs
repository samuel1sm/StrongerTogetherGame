using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class Teleport : MonoBehaviour
{
    [SerializeField] private int timeToLoad = 3;
    private bool _coroutineStarted = false;

    IEnumerator EndLevel()
    {
        _coroutineStarted = true;
        int value = 0;
        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            value++;
            if (value == timeToLoad)
                break;
            
        }
        SceneController.LoadNextScene();

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_coroutineStarted)
        {
            StartCoroutine(nameof(EndLevel));
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_coroutineStarted)
        {
            StartCoroutine(nameof(EndLevel));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _coroutineStarted)
        {
            StopCoroutine(nameof(EndLevel));
            _coroutineStarted = false;
        }
    }
}