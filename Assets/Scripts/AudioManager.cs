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

    private void Start()
    {
        DontDestroyOnLoad(this);
        PlayBgmMenu();
        Init();
    }

    private void Init()
    {
        masterMixer.SetFloat("Mastervol", Mathf.Log(PlayerPrefs.GetFloat("Mastervol")) * 20);
        masterMixer.SetFloat("BGMvol", Mathf.Log(PlayerPrefs.GetFloat("BGMvol")) * 20);
        masterMixer.SetFloat("SFXvol", Mathf.Log(PlayerPrefs.GetFloat("SFXvol")) * 20);
    }

    public void setMasterVolume(Slider slider)
    {
        masterMixer.SetFloat("Mastervol", Mathf.Log(slider.value) * 20);
        PlayerPrefs.SetFloat("Mastervol", slider.value);
    }

    public void setBGMVolume(Slider slider)
    {
        masterMixer.SetFloat("BGMvol", Mathf.Log(slider.value) * 20);
        PlayerPrefs.SetFloat("BGMvol", slider.value);
    }

    public void setSFXVolume(Slider slider)
    {
        masterMixer.SetFloat("SFXvol", Mathf.Log(slider.value) * 20);
        PlayerPrefs.SetFloat("SFXvol", slider.value);
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