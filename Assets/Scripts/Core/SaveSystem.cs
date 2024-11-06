using UnityEngine;

public static class SaveSystem
{
    private const string HighScoreKey = "HighScore";

    public static void SaveHighScore(int score)
    {
        // Saves the high score if it's higher than the current saved high score.
        int currentHighScore = GetHighScore();
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
            PlayerPrefs.Save();
            Debug.Log("New high score saved: " + score);
        }
        Debug.Log("New high score saved: " + score);
    }

    public static int GetHighScore()
    {
        // Loads the saved high score.
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("All saved data cleared.");
    }
}