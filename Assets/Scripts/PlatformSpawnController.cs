using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnController : MonoBehaviour
{
    public GameObject spawnObject;
    public bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning)
        {
            SpawnPlatforms();
            isSpawning = false;
        }
    }

    void SpawnPlatforms()
    { 
        GameObject topSpawn = Instantiate(spawnObject, new Vector2(0,5f), Quaternion.identity);
        GameObject bottomSpawn = Instantiate(spawnObject, new Vector2(0,-5f), Quaternion.identity);
    }
}
