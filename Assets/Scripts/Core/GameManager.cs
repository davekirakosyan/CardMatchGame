using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int defaultRows = 4;
    public int defaultColumns = 4;
    public int score = 0;

    [Header("References")]
    public LayoutManager layoutManager;
    public ScoreManager scoreManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartNewGame();
    }

    // Starts a new game with the default board size.
    public void StartNewGame()
    {
        //setup board and reset game 
        score = 0;
        scoreManager.UpdateScore(score);
        scoreManager.UpdateHighScore();
        layoutManager.SetupBoard(defaultRows, defaultColumns);
        GameMechanics.Instance.ResetGame();
    }

    
    public void AddScore(int points)
    {
        score+=points;
        scoreManager.UpdateScore(score);
        // Adds points to the score and updates the UI.
    }

    public void GameOver()
    {
        // Ends the game and displays a win message.
        scoreManager.SaveHighScore(score);
        scoreManager.UpdateHighScore();
        Debug.Log("Game Over! All pairs matched!");
    }
}