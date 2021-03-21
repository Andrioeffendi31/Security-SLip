using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class InfoRandomizer
{
    // Temporary, will change to read from file
    string[] listOfFirstName = {
        "Nikki", "Bill", "Patrick", "Daniel", "Alex"
    };
    string[] listOfMiddleName = {
        "Hines", "Huff", "Matt", "Ence"
    };
    string[] listOfLastName = {
        "Benson", "Sears", "Coffey", "Everett", "Grant"
    };

    public InfoRandomizer() {}

    public Character GetRandomizeCharacter()
    {
        Character generated = new Character();

        // Generate character full name
        generated.firstName = listOfFirstName[RandomNumber(0, listOfFirstName.Length)];
        generated.middleName = listOfMiddleName[RandomNumber(0, listOfMiddleName.Length)];
        generated.lastName = listOfLastName[RandomNumber(0, listOfLastName.Length)];

        return generated;
    }

    public int RandomNumber(int min, int max) { return Random.Range(min, max); }
    public DateTime GetRandomDate(DateTime dateTimeFrom, DateTime dateTimeTo)
    {
        int range = (dateTimeTo - dateTimeFrom).Days;
        return dateTimeFrom.AddDays(Random.Range(0, range));
    }


}
