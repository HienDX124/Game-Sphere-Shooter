using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class utilityScript : MonoBehaviour
{
    public static utilityScript instance;
    [HideInInspector] public bool isPausing;

    void Start()
    {
        instance = this;
        Pause();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        // Time.timeScale = 0.0f;
        SetSpeedEnemyToZero();

        isPausing = true;

    }

    private static void SetSpeedEnemyToZero()
    {
        GameObject[] enemiesGO = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemiesGO.Length; i++)
        {
            enemy enemyComponent = enemiesGO[i].GetComponent<enemy>();
            enemyComponent.currentSpeed = 0f;
        }
    }

    public void UnPause()
    {
        // Time.timeScale = 1.0f;
        SetSpeedEnemyToNormal();

        isPausing = false;
    }

    private static void SetSpeedEnemyToNormal()
    {
        GameObject[] enemiesGO = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemiesGO.Length; i++)
        {
            enemy enemyComponent = enemiesGO[i].GetComponent<enemy>();
            enemyComponent.currentSpeed = enemyComponent.speed;
        }
    }
}
