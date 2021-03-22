using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Resume(){
        Time.timeScale = 1f;
        //SceneManager.LoadScene(0);
    }

    public void GoToOption(){
        //SceneManager.LoadScene(0);
    }

    public void GoToMainMenu(){
        Time.timeScale = 1f;
        //SceneManager.LoadScene(0);
    }
}
