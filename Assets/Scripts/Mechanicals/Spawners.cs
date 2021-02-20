using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnerTypes{
    Platform, Knifes
}

public class Spawners : MonoBehaviour
{
    [SerializeField] private bool destroyOnSpawn;
    [SerializeField] private GameObject spawnable;
    [SerializeField] private int maxItemQuantity;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float destroyDelay;
    [SerializeField] private Vector3 itemSpeed;
    [SerializeField] private SpawnerTypes spawnerType;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnItem()
    {
        var transform1 = transform;

        while (true)
        {

            GameObject item = Instantiate(spawnable, transform, true);
            item.transform.localPosition = Vector3.zero;

            switch (spawnerType)
            {
                case SpawnerTypes.Platform:
                    item.transform.GetComponent<MoveblePlatform>().StartMove(itemSpeed);
                    break;
                case SpawnerTypes.Knifes:
                    item.transform.GetComponent<Rigidbody2D>().velocity = itemSpeed;
                    break;
  
                
            }

            if (destroyOnSpawn)
            {
                Destroy(item, destroyDelay);
            }
            
            yield return new WaitUntil(() => transform1.childCount < maxItemQuantity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}