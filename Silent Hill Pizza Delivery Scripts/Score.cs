using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    private static Score instance;
    private bool multiplier;
    public static Score GetInstance()
    {
        return instance;
    }
    public int GetScore()
    {
        return score;
    }
    public void ScoreUp()
    {
        score++;

        if (multiplier)//x2 score
        {
            score++;
        }
    }
    public void Times2()
    {
        multiplier = true;
    }

    public void Times1()
    {
        multiplier = false;
    }

    private void Awake()
    {
        instance = this;
        multiplier = false;
    }

    public static int GetHighscore()//simple highscore setting using PlayerPrefs
    {
        return PlayerPrefs.GetInt("highscore");
    }

    public static bool TrySetNewHighscore(int score)
    {
        int currentHighscore = GetHighscore();

        if(score > currentHighscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            return true;
        }

        else
        {
            return false;
        }
    }


}//class
