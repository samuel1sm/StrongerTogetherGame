using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
     public static Player Player;

     private void Awake()
     {
         GameManager.Player = FindObjectOfType<Player>();
     }
     
        
     // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
