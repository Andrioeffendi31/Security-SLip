using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorials : MonoBehaviour
{
    public void GoToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void BackToMenu()
    {
        Destroy(GameObject.Find("Game Manager"));
        Destroy(GameObject.Find("Audio Manager"));

        SceneManager.LoadScene("MainMenu");
    }
}
