using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pukeSpawnerController : MonoBehaviour
{
    public GameObject[] food;
    public float spawnRange;
    public float spawnDelay;

    void Start()
    {
        InvokeRepeating("spawnFood", 0, spawnDelay);
    }

    void spawnFood()
    {
        int index = Random.Range(0, food.Length);
        Vector2 pos = new Vector2(Random.Range(-spawnRange, spawnRange), transform.position.y);

        Instantiate(food[index], pos, Quaternion.identity, this.transform);
    }
    
}
