using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    internal int BestScoreGet()
    {
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }

        return PlayerPrefs.GetInt("BestScore");
    }

    internal int ScoreCheck(int currentScore)
    {
        if(currentScore > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
        }

        return PlayerPrefs.GetInt("BestScore");
    }
}
