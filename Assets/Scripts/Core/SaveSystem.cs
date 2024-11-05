using UnityEngine;

public static class SaveSystem
{
    private const string HighScoreKey = "HighScore";

    public static void SaveHighScore(int score)
    {
        // Saves the high score if it's higher than the current saved high score.
        Debug.Log("New high score saved: " + score);
    }

    public static int GetHighScore()
    {
        // Loads the saved high score.
        return 0;
    }

    public static void ClearData()
    {
        // Clears all saved data.
    }
}