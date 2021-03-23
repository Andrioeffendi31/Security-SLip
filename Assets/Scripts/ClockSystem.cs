using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockSystem : MonoBehaviour
{
    const float degreesPerHour = 30f,
                degreesPerMinute = 6f,
                degreesPerSecond = 6f;

    private DateTime waktu;
    AudioManager AudioManager;
    public Transform hoursTransform, minutesTransform, secondsTransform;

    public Text computerUI_date;
    public Text computerUI_clock;

    private void Start()
    {
        AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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

    public DateTime GetCurrentDateTime()
    {
        return waktu;
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
        computerUI_clock.text = waktu.ToString("HH:mm");
        computerUI_date.text = waktu.ToString("dddd, MMMM dd");
        if (GameConfiguration.DebugMode) Debug.Log((int)(waktu.Hour) + ":" + (int)(waktu.Minute) + ":" + (int)(waktu.Second));
        yield return new WaitForSeconds(1);
        StartCoroutine(TickTime());

    }
}