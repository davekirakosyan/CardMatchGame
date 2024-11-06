using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int currentScore;

    public void UpdateScore(int score)
    {
        currentScore = score;
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore;
    }

    public void UpdateHighScore()
    {
        int highscore = SaveSystem.GetHighScore();
        highScoreText.text = "High Score: " + highscore;
    }

    public void SaveHighScore(int highScore)
    {
        SaveSystem.SaveHighScore(highScore);
    }
}