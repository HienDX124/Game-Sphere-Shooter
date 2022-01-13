using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float delay;
    [HideInInspector] public float currentTime;
    public GameObject enemy;

    void Start()
    {
        // InvokeRepeating("SpawnEnemy", 0.0f, delay);
        currentTime = 0;
    }

    void Update()
    {
        if (!utilityScript.instance.isPausing)
        {
            if (currentTime - Time.deltaTime < 0)
            {
                SpawnEnemy();
                currentTime = delay;
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }
    }

    void SpawnEnemy()
    {
        int randomPos = (int)Random.Range(0, transform.childCount);
        Instantiate(enemy, transform.GetChild(randomPos).position, enemy.transform.rotation);
    }

}
