using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSystem : MonoBehaviour
{
    const float degreesPerHour = 30f,
                degreesPerMinute = 6f,
                degreesPerSecond = 6f;

    private DateTime waktu;
    AudioManager AudioManager;
    public Transform hoursTransform, minutesTransform, secondsTransform;

    private void Start()
    {
        AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        SetStartDateTime(2021, 3, 21, 7, 0, 0);
        StartClock();
    }

    private void Update()
    {
        // Update clock needles
        hoursTransform.localRotation = Quaternion.Euler(180 + waktu.Hour * degreesPerHour, 0, 0);
        minutesTransform.localRotation = Quaternion.Euler(180 + waktu.Minute * degreesPerMinute, 0, 0);
        secondsTransform.localRotation = Quaternion.Euler(180 + waktu.Second * degreesPerSecond, 0, 0);
    }

    /// <summary>
    /// Set gameplay start date and time
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    public void SetStartDateTime(int year, int month, int day, int hour, int minute, int second)
    {
        waktu = new DateTime(year, month, day, hour, minute, second);
        if (GameConfiguration.DebugMode) Debug.Log("Start DateTime :" + waktu);
    }

    /// <summary>
    /// Start the current clock
    /// </summary>
    public void StartClock()
    {
        AudioManager.PlaySfxClock();
        StartCoroutine(TickTime());
    }

    private IEnumerator TickTime()
    {
        waktu = waktu.AddSeconds(GameConfiguration.secondPerRealSecond);
        if (GameConfiguration.DebugMode) Debug.Log((int)(waktu.Hour) + ":" + (int)(waktu.Minute) + ":" + (int)(waktu.Second));
        yield return new WaitForSeconds(1);
        StartCoroutine(TickTime());

    }
}