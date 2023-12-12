using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    public Canvas MainMenuUI;
    public Canvas SettingsUI;
    // Initialization
    void Awake()
    {

    }
    void Start()
    {
        Instance = this;
        DefaultMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DefaultMenu();
        }
    }

    void DefaultMenu()
    {
        ShowMainMenu();
        HideSettingsMenu();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void ShowMainMenu()
    {
        MainMenuUI.gameObject.SetActive(true);
    }

    public void HideMainMenu()
    {
        MainMenuUI.gameObject.SetActive(false);
    }

    public void ShowSettingsMenu()
    {
        SettingsUI.gameObject.SetActive(true);
    }

    public void HideSettingsMenu()
    {
        SettingsUI.gameObject.SetActive(false);
    }
}
