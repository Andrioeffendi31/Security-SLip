using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameplayController gameplayController;

    [SerializeField]
    private AudioManager audioManager;

    private bool isPlaying;

    public int finalScore;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        GameConfiguration.Initialize();
        DontDestroyOnLoad(this);

        isPlaying = false;
        Cursor.lockState = CursorLockMode.Confined;

        finalScore = 0;
    }

    public void StartGame(GameplayController gameplayController)
    {
        this.gameplayController = gameplayController;
        isPlaying = true;
    }

    public void EndGame(int finalScore)
    {
        this.finalScore = finalScore;

        isPlaying = false;

        SceneManager.LoadScene("Score");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }
}
