using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Times : MonoBehaviour
{
    public int Tahun, bulan, hari, jam, menit, detik;
    public DateTime date1;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        DateStart();
    }

    // Update is called once per frame
    void Update()
    {
       // DateStart();
    }

    public void DateStart()
    {
        date1 = new DateTime(Tahun, bulan, hari, jam, menit, detik);
        
    }

    public DateTime currentTime()
    {
        
        //Debug.Log(date1);
        return date1;
    }
}
