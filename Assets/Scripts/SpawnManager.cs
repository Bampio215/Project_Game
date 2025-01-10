using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float xSpawnRange = 10;
    private float xSpawnpos = 30;
    private float zSpawnpos = 20;
    private float zSpawnRange = 6;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        //CancelInvoke("SpawnRandomAnimal"); Hủy hàm InvokeRepeating
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            //Instantiate(animalPrefabs[Random.Range(0, animalPrefabs.Length)], new Vector3(Random.Range(-10, 10), 0, 20), animalPrefabs[Random.Range(0, animalPrefabs.Length)].transform.rotation);
            SpawnRandomAnimal();
        }*/
    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int index = Random.Range(1, 4);
        Vector3 spawnpos;
        Quaternion rotation;
        if (index == 1)
        {
            spawnpos = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), 0, zSpawnpos);
            rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (index == 2)
        {
            spawnpos = new Vector3(-xSpawnpos, 0, Random.Range(zSpawnRange, 2.5f * zSpawnRange));
            rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            spawnpos = new Vector3(xSpawnpos, 0, Random.Range(zSpawnRange, 2.5f * zSpawnRange));
            rotation = Quaternion.Euler(0, 270, 0);
        }
        Instantiate(animalPrefabs[animalIndex], spawnpos, rotation);

    }
}

