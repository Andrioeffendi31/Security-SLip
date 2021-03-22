using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Checker : MonoBehaviour
{
    private DateTime waktu;

    // Start is called before the first frame update
    void Start()
    {
        waktu = new DateTime(2021, 3, 22, 17, 0, 0);
        Debug.Log(waktu);
        Info testInfo = new Info();
        expire(testInfo);
       // Debug.Log(testInfo.expired);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool expire(Info test) 
    {
        Debug.Log("expired"+test.expired);
        if (test.expired > waktu)
        {
            Debug.Log("false");
            return false;//izin belum expired
        }
        Debug.Log("True");
        return true;//izin sudah expired
        
    }
}
