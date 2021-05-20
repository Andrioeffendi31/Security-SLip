using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    [SerializeField]
    private Text score;

    private GameObject gameManager;

    private GameObject audioManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager");
        audioManager = GameObject.Find("Audio Manager");

        score.text = gameManager.GetComponent<GameManager>().finalScore.ToString();
        audioManager.GetComponent<AudioManager>().PlayBgmFinal();
        audioManager.GetComponent<AudioManager>().audioSourceSFX.Stop();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void GoToMainMenu()
    {
        Destroy(gameManager);
        Destroy(audioManager);

        SceneManager.LoadScene("MainMenu");
    }
}
