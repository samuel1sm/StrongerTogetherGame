using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D _platformEffector;
    private bool isInPlataform = false;

    private void Update()
    {
        if (isInPlataform)
        {
            if (GameManager.Player.IsPressingDown())
            {
                _platformEffector.rotationalOffset = 180;
            }
        }
    }

    private void Start()
    {
        _platformEffector = GetComponent<PlatformEffector2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInPlataform = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInPlataform = false;
            _platformEffector.rotationalOffset = 0;

        }
    }

    private void VerifyIfPlayerIsPressingDown(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("test2");

            if (GameManager.Player.IsPressingDown())
            {
                print("test");
                _platformEffector.rotationalOffset = 180;
            }
        }
    }
}