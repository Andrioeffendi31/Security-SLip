using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class Sc_ClockSystem : MonoBehaviour
{
    private DateTime waktu;
    private float speedl;
    const float degreesPerHour = 30f,
                degreesPerMinute = 6f,
                degreesPerSecond = 6f;
    private float startTime;
    private float stopTime;

    private float timerTime;
    public Transform hoursTransform, minutesTransform, secondsTransform;

    private void Awake()
    {
        stopTime = 0;
        startTime = Time.time;
    }


    private void Start()
    {
        speedl = gameObject.GetComponent<Sc_Times>().speed;
        waktu = gameObject.GetComponent<Sc_Times>().currentTime();
        Debug.Log(waktu);
        hoursTransform.eulerAngles = new Vector3(150f, 0f, 0f);
        //InvokeRepeating("repeat",1f,1f);
        StartCoroutine(repeat());

    }



    private void Update()
    {
       
        timerTime = stopTime + (Time.time - startTime);
        float minutesInt = timerTime / 60;
        float secondsInt = timerTime % 60;
        float hourInt = timerTime / 3600;
        // Debug.Log(waktu.Second);

        // waktu = waktu.AddMilliseconds(10);
        
        hoursTransform.localRotation = Quaternion.Euler(waktu.Hour * degreesPerHour, 0f,  0);
        minutesTransform.localRotation = Quaternion.Euler(waktu.Minute * degreesPerMinute, 0f,  0);
        secondsTransform.localRotation = Quaternion.Euler(waktu.Second * degreesPerSecond, 0f, 0); 
        //Debug.Log((int)(waktu.Hour) +":"+ (int)(waktu.Minute) +":"+ (int)(waktu.Second));
    }

   /* public void repeat()
    {
        Debug.Log("test");
       waktu =  waktu.AddSeconds(1);
    }*/

    private IEnumerator repeat()
    {
        waktu = waktu.AddSeconds(speedl);
        Debug.Log((int)(waktu.Hour) + ":" + (int)(waktu.Minute) + ":" + (int)(waktu.Second));
        yield return new WaitForSeconds(1);
        StartCoroutine(repeat());

    }
}