using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ComponentType{
    Left, Right, Jump, Down
}

public class CollectableComponents : MonoBehaviour
{
    [SerializeField] private ComponentType _componentType;


    

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySound(Sound.CollectingItem);

            switch (_componentType)
            {
                case ComponentType.Left:
                    GameManager.Player.ChangeHasLeft(true);
                    break;
                
                case ComponentType.Right:
                    GameManager.Player.ChangeHasRight(true);
                    break;
                
                case ComponentType.Jump:
                    GameManager.Player.ChangeHasJump(true);
                    break;
                
                case ComponentType.Down:
                    GameManager.Player.ChangeHasDown(true);
                    break;
 
            }
            
            Destroy(gameObject);
        }
    }
}
