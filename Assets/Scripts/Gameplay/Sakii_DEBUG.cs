using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sakii_DEBUG : MonoBehaviour
{
    private readonly InfoRandomizer infoRandomizer = new InfoRandomizer();

    private void Start()
    {
        Character test = infoRandomizer.GetRandomizeCharacter();

        Debug.Log(test.firstName);
        Debug.Log(test.middleName);
        Debug.Log(test.lastName);

       
    }
}
