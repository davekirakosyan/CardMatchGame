using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text score;
    public Button restart;
    public Button mainMenu;
    public Button quit;

    void OnEnable()
    {
        //Register Button Events
        restart.onClick.AddListener(() => GameManager.Instance.StartNewGame());
        mainMenu.onClick.AddListener(() => GameManager.Instance.MainMenu());
        quit.onClick.AddListener(()=>GameManager.Instance.QuitGame());
        score.text = "Score: "+ GameManager.Instance.score.ToString();
    }

}
