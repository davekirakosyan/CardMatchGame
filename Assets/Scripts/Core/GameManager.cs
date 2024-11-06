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

    [Header("UI Panels")]
    public GameObject gameUIPanel;
    public GameObject gameOverPanel;
    public GameObject optionsPanel;
    public GameObject mainMenuPanel;

    public AudioManager audioManager;

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
        audioManager.audioSource.volume = SaveSystem.GetSoundVolume();
    }

    // Starts a new game with the default board size.
    public void StartNewGame()
    {
        //setup board and reset game 
        score = 0;
        gameUIPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        optionsPanel.SetActive(false);
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

    public void UpdateCombo(int combo)
    {
        scoreManager.UpdateCombo(combo);
    }

    public void GameOver()
    {
        // Ends the game and displays a win message.
        scoreManager.SaveHighScore(score);
        scoreManager.UpdateHighScore();
        gameUIPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        audioManager.PlayGameOverAudio();
        Debug.Log("Game Over! All pairs matched!");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void MainMenu()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
}