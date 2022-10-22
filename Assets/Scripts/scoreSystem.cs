using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreSystem : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Update()
    {
        setHighScore();
    }

    public void addScore()
    {
        score += 1;
        displayScore();
    }

    public void displayScore()
    {
        //Debug.Log(score);
        scoreText.text = score.ToString();
    }

    public void setHighScore()
    {
        if(score > highScore)
        {
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }

}
