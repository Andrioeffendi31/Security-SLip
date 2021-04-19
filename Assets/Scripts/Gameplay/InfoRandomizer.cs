using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class InfoRandomizer
{
    // Temporary, will change to read from file
    string[] listOfFirstName = {
        "Nikki", "Bill", "Patrick", "Daniel", "Alex", "Michael"
    };

    string[] listOfMiddleName = {
        "Hines", "Huff", "Matt", "Ence", "Rio"
    };
    
    string[] listOfLastName = {
        "Benson", "Sears", "Coffey", "Everett", "Grant", "Fernando"
    };

    public InfoRandomizer() {}

    public string GetRandomizeFirstName()
    {
        return listOfFirstName[RandomNumber(0, listOfFirstName.Length)];
    }

    public string GetRandomizeMiddleName()
    {
        return listOfMiddleName[RandomNumber(0, listOfMiddleName.Length)];
    }

    public string GetRandomizeLastName()
    {
        return listOfLastName[RandomNumber(0, listOfLastName.Length)];
    }
    
    public int GetRandomizeGender()
    {
        return RandomNumber(0, 2);
    }

    public int RandomNumber(int min, int max) { return Random.Range(min, max); }
    public DateTime GetRandomDate(DateTime dateTimeFrom, DateTime dateTimeTo)
    {
        int range = (dateTimeTo - dateTimeFrom).Days;
        return dateTimeFrom.AddDays(Random.Range(0, range));
    }
}
