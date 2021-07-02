using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleMenuSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject goldenApplePrefab;
    public GameObject bombPrefab;

    public float chanceToDropGoldenApple = 10f;
    public float chanceToDropBomb = 20f;


    private void Start()
    {
        InvokeRepeating("SpawnApple", 0.5f, 0.5f);
        InvokeRepeating("SpawnApple", 1.0f, 0.7f);
        InvokeRepeating("SpawnApple", 1.5f, 0.9f);
        
    }

    void SpawnApple()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-2f, 2.5f), 4f, -7f);
        
        if (UnityEngine.Random.Range(0, 100) < chanceToDropGoldenApple)
        {
            GameObject goldenApple = Instantiate<GameObject>(goldenApplePrefab);
            goldenApple.transform.position = spawnPoint;

        }
        else if (UnityEngine.Random.Range(0, 100) < chanceToDropBomb)
        {
            GameObject bomb = Instantiate<GameObject>(bombPrefab);
            bomb.transform.position = spawnPoint;

        }
        else
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = spawnPoint;

        }

    }
}
