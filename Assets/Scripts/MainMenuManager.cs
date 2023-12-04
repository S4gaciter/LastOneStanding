using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    Canvas MainMenuUI;
    Canvas SettingsUI;
    // Initialization
    void Awake()
    {
        MainMenuUI = GameObject.Find("MainMenuUI").GetComponent<Canvas>();
        SettingsUI = GameObject.Find("SettingsUI").GetComponent<Canvas>();
    }
    void Start()
    {
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
