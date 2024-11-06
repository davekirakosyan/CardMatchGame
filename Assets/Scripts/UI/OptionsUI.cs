using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public Button restart;
    public Button mainMenu;
    public Button quit;
    public Button back;

    void OnEnable()
    {
        //Register Button Events
        restart.onClick.AddListener(() => GameManager.Instance.StartNewGame());
        mainMenu.onClick.AddListener(() => GameManager.Instance.MainMenu());
        back.onClick.AddListener(() => CloseOptions(true));
        quit.onClick.AddListener(() => GameManager.Instance.QuitGame());
    }

    public void CloseOptions(bool close)
    {
        this.gameObject.SetActive(!close);
    }
}
