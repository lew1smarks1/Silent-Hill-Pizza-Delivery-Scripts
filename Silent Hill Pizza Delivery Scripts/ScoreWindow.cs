using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    //manages the score window text, simple enough
    private Text highscoreText;
    private Text scoreText;
    private void Awake()
    {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        highscoreText = transform.Find("HighscoreText").GetComponent <Text>();
    }
    private void Start()
    {
        highscoreText.text ="Highscore: " + Score.GetHighscore().ToString();
    }

    private void Update()
    {
        scoreText.text = "Score: " + Score.GetInstance().GetScore().ToString();
    }
}
