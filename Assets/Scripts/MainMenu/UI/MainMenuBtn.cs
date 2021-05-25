using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBtn : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private Slider masterVolume;

    [SerializeField]
    private Slider bgmVolume;

    [SerializeField]
    private Slider sfxVolume;

    [SerializeField]
    private Animator mainMenuAnimator;

    [SerializeField]
    private Animator settingMenuAnimator;

    public bool animationComplete;

    void Start()
    {
        Init();
        ToggleMainMenu();
    }

    private void Init()
    {
        masterVolume.value = PlayerPrefs.GetFloat("Mastervol");
        bgmVolume.value = PlayerPrefs.GetFloat("BGMvol");
        sfxVolume.value = PlayerPrefs.GetFloat("SFXvol");
    }

    private void ToggleMainMenu()
    {
        mainMenuAnimator.SetTrigger("MenuTrigger");
    }

    private void ToggleSettingMenu()
    {
        settingMenuAnimator.SetTrigger("MenuTrigger");
    }

    public void GoToGameplay()
    {
        int playTimes = 0;
        
        playTimes = PlayerPrefs.GetInt("PlayTimes");

        if (playTimes > 3)
        {
            SceneManager.LoadScene("Gameplay");
        }
        else
        {
            PlayerPrefs.SetInt("PlayTimes", playTimes + 1);
            SceneManager.LoadScene("Tutorial");
        }
        
    }

    public void GoToSetting()
    {
        if (animationComplete)
        {
            // Hide Main Menu
            ToggleMainMenu();

            // Show Settings
            ToggleSettingMenu();

            animationComplete = false;
        }
    }

    public void BackToMainMenu()
    {
        if (animationComplete)
        {
            // Hide Settings
            ToggleSettingMenu();

            // Show Main Menu
            ToggleMainMenu();

            animationComplete = false;
        }
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
