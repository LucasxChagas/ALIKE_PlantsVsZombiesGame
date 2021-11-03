using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    
    public GameObject[] spawnLocations;
    public GameObject[] zombiesPrefab;

    void Start() 
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
        InvokeRepeating("InstantiateZombie", 15, 7);
    }

    void InstantiateZombie()
    {
        int spawn = Random.Range(0, spawnLocations.Length);
        int prefab = Random.Range(0, zombiesPrefab.Length);
        Instantiate(zombiesPrefab[prefab], spawnLocations[spawn].transform.position, Quaternion.identity);
    }
    
}
