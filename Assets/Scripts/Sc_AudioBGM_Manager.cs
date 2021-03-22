using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_AudioBGM_Manager : MonoBehaviour
{
    public AudioClip BGM_Menu;
    public AudioClip BGM_Gameplay;
    public AudioClip BGM_Final;
    public AudioClip sfxDoor;
    public AudioClip sfxClock;
    public AudioClip sfxAlarm;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }


    public void PlayBgmMenu()
    {
        audioSource.clip = BGM_Menu;
        audioSource.Play();
    }

    public void PlayBgmGamePlay()
    {
        audioSource.clip = BGM_Gameplay;
        audioSource.Play();
    }

    public void PlayBgmFinal()
    {
        audioSource.clip = BGM_Final;
        audioSource.Play();
    }

    public void PlaySfxClock()
    {
        audioSource.loop = true;
        audioSource.clip = sfxClock;
        audioSource.Play();
    }

    public void PlaySfxDoor()
    {
        audioSource.clip = sfxDoor;
        audioSource.Play();
    }
    public void PlaySfxAlarm()
    {
        audioSource.clip = sfxAlarm;
        audioSource.Play();
    }

}
