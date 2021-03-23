using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtn : MonoBehaviour
{
    public GameManager gameManager;

    public void GoToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
        gameManager.isPlaying = true;
    }

    public void GoToSetting()
    {
        // SceneManager.LoadScene("Settings");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
