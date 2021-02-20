using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveblePlatform : MonoBehaviour
{
    
    private Vector3 velocity;
    private bool _isMoving = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.gameObject.transform.SetParent(null);
    }

    private void FixedUpdate()
    {
        if (_isMoving)
            transform.position += velocity * Time.deltaTime;
    }

    public void StartMove(Vector3 itemSpeed)
    {
        velocity = itemSpeed;
        _isMoving = true;
    }
}