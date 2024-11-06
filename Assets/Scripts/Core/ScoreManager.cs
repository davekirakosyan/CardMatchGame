using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI comboText;
    public int currentScore;

    public void UpdateScore(int score)
    {
        currentScore = score;
        scoreText.text = "Score: " + score;
    }

    public void UpdateCombo(int combo)
    {
        comboText.text = "X" + combo;
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