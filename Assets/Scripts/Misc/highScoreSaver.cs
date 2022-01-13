using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class highScoreSaver : MonoBehaviour
{
    public static highScoreSaver instance;
    private int highScore;
    private string highScorePathFile;
    [HideInInspector] public string dataLine;

    void Start()
    {

        // Sure singleton
        if (instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        // Create new file to save highScore 
        highScorePathFile = Application.persistentDataPath + "HighScoreSaver.txt";
        if (!File.Exists(highScorePathFile))
        {
            using (var fs = File.Create(highScorePathFile)) { }
        }

        // Read data in file
        dataLine = File.ReadAllText(highScorePathFile);

        highScore = int.Parse(dataLine);
    }

    public void UpdateNewHighScore(int newHighScore)
    {
        WriteToFile(newHighScore.ToString());
        highScore = newHighScore;
    }

    private void WriteToFile(string str)
    {
        File.WriteAllText(highScorePathFile, str);
    }

    public int GetHighScore()
    {
        return highScore;
    }
}
