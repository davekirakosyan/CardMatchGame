using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUI : MonoBehaviour
{
    public Button start;
    public Button quit;
    public TMP_Dropdown layout;

    void OnEnable()
    {
        //Register Button Events
        start.onClick.AddListener(() => CalculateLayout());
        quit.onClick.AddListener(() => GameManager.Instance.QuitGame());

    }

    void CalculateLayout()
    {
        string layoutText = layout.options[layout.value].text;
        string[] board = layoutText.Split(new[] { 'x' }, 2);

        int width = board.Length > 0 && int.TryParse(board[0], out int temp1) ? temp1 : 0;
        int height = board.Length > 1 && int.TryParse(board[1], out int temp2) ? temp2 : 0;

        GameManager.Instance.defaultColumns = width;
        GameManager.Instance.defaultRows = height;

        GameManager.Instance.StartNewGame();

        this.gameObject.SetActive(false);
    }
}
