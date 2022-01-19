using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
{
    public static healthManager instance;

    public Text healthText;
    public Text yourScoreText;
    public Text highScoreText;

    public int health;

    public GameObject gameOverGO;
    public GameObject explosionPrefab;

    void Awake()
    {
        if (instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        UpdateHealth();
    }

    void UpdateHealth()
    {
        if (health <= 0) { GameOver(); return; }
        healthText.text = "Health: " + health.ToString();
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        UpdateHealth();
    }

    void GameOver()
    {
        int yourScoreValue = scoreManager.instance.GetCurrentScore();
        int highScoreValue = highScoreSaver.instance.GetHighScore();

        healthText.text = "Health: 0";
        GameObject instaceExplosion = Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);

        // Destroy(this.gameObject);

        gameOverGO.SetActive(true);

        yourScoreText.text = yourScoreValue.ToString();

        if (yourScoreValue <= highScoreValue)
        {
            highScoreText.text = highScoreValue.ToString();
        }
        else
        {
            highScoreSaver.instance.UpdateNewHighScore(yourScoreValue);
        }

        Destroy(instaceExplosion, 3.0f);

        StartCoroutine(utilityScript.instance.FreezeGameTimeRoutine(2f));
    }
}
