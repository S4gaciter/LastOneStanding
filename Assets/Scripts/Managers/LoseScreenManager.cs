using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenManager : MonoBehaviour
{
    public static LoseScreenManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void Replay()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
