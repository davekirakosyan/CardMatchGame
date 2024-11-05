using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
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
}