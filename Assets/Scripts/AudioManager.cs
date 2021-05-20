using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip BGM_Menu,
                     BGM_Final,
                     sfxDoor,
                     sfxClock,
                     sfxAlarm;

    [SerializeField]
    public AudioClip[] BGM_Gameplay;

    public AudioSource audioSourceBGM,
                       audioSourceSFX;

    public AudioMixer masterMixer;

    public void setMasterVolume(float sliderValue)
    {
        masterMixer.SetFloat("Mastervol", Mathf.Log(sliderValue) * 20);
        PlayerPrefs.SetFloat("Mastervol", sliderValue);
    }

    public void setBGMVolume(float sliderValue)
    {
        masterMixer.SetFloat("BGMvol", Mathf.Log(sliderValue) * 20);
        PlayerPrefs.SetFloat("BGMvol", sliderValue);
    }

    public void setSFXVolume(float sliderValue)
    {
        masterMixer.SetFloat("SFXvol", Mathf.Log(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXvol", sliderValue);
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        PlayBgmMenu();
    }

    public void PlayBgmMenu()
    {
        audioSourceBGM.Stop();
        audioSourceBGM.clip = BGM_Menu;
        audioSourceBGM.Play();
        audioSourceBGM.loop = true;
    }

    public void PlayBgmGamePlay()
    {
        audioSourceBGM.clip = BGM_Gameplay[GameConfiguration.musicLevel];
        audioSourceBGM.Stop();
        audioSourceBGM.Play();
        audioSourceBGM.loop = true;
    }

    public void PlayBgmFinal()
    {
        audioSourceBGM.loop = false;
        audioSourceBGM.Stop();
        audioSourceBGM.clip = BGM_Final;
        audioSourceBGM.Play();
    }

    public void PlaySfxClock()
    {
        audioSourceSFX.loop = true;
        audioSourceSFX.clip = sfxClock;
        audioSourceSFX.Play();
    }

    public void PlaySfxDoor()
    {
        audioSourceBGM.clip = sfxDoor;
        audioSourceBGM.Play();
    }

    public void PlaySfxAlarm()
    {
        audioSourceBGM.clip = sfxAlarm;
        audioSourceBGM.Play();
    }
}