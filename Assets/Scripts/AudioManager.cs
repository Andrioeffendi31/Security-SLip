using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip BGM_Menu,
                     BGM_Gameplay,
                     BGM_Final,
                     sfxDoor,
                     sfxClock,
                     sfxAlarm;

    public AudioSource audioSourceBGM,
                       audioSourceSFX;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void PlayBgmMenu()
    {
        audioSourceBGM.clip = BGM_Menu;
        audioSourceBGM.Play();
    }

    public void PlayBgmGamePlay()
    {
        audioSourceBGM.clip = BGM_Gameplay;
        audioSourceBGM.Play();
    }

    public void PlayBgmFinal()
    {
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